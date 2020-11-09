import React, { ReactElement } from 'react';
import { Link } from 'react-router-dom';
import { Question } from './interfaces';
import QuestionPreview from './QuestionPreview';

export default function Home({ questions, incrementQuestionVisits }: { questions: Array<Question>, incrementQuestionVisits(id: number): void }): ReactElement {
  return (
    <div>
      <h2>Questions</h2>
      <Link to="/ask-question">Ask Question</Link>
      { questions.map((question, idx) => <QuestionPreview incrementQuestionVisits={incrementQuestionVisits} question={question} key={idx} />) }
    </div>
  );
}