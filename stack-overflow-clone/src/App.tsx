import React, { ReactElement, useState } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Question } from './interfaces';
import Home from './Home';
import QuestionForm from './QuestionForm';
import QuestionPage from './QuestionPage';

function useLocalStorage<T>(
  key: string,
  defaultValue?: T
): [T, (value: T) => void] {
  const [value, setValue] = useState(
    JSON.parse(localStorage.getItem(key)!) || defaultValue
  );

  return [
    value,
    function (value: T): void {
      setValue(value);
      localStorage.setItem(key, JSON.stringify(value));
    },
  ];
}

const defaultQuestions: Array<Question> = [
  {
    id: 1,
    answers: [],
    author: 'Ivan',
    content:
      "Type { id: number; }' is missing the following properties from type 'Question': author, title, content, viewsCount, and 2 more.  TS2740",
    title: 'TS error',
    creationDate: new Date().toString(),
    viewsCount: 2,
  }
];

export default function App(): ReactElement {
  const [questions, setQuestions] = useLocalStorage<Array<Question>>(
    'questions',
    defaultQuestions
  );

  function incrementQuestionVisits(id: number): void {
    setQuestions(questions.map(q => {
      if (q.id === id) {
        q.viewsCount++;
      }
      return q;
    }))
  }

  function addComment(id: number, answer: string): void {
    setQuestions(questions.map(q => {
      if (q.id === id) {
        q.answers.push(answer);
      }
      return q;
    }))
  }

  return (
    <BrowserRouter>
      <div className="wrapper">
        <h1>Stack Overflow clone</h1>
        <Switch>
          <Route path="/ask-question">
            <QuestionForm addQuestion={question => setQuestions(questions.concat([question]))} />
          </Route>
          <Route path="/question/:id" render={props => <QuestionPage addComment={addComment} question={questions.find(q => q.id === +props.match.params.id)!}></QuestionPage>} />
          <Route path="/">
            <Home incrementQuestionVisits={incrementQuestionVisits} questions={questions} />
          </Route>
        </Switch>
      </div>
    </BrowserRouter>
  );
}
