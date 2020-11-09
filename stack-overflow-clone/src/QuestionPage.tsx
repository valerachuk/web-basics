import React, { ReactElement, useState } from 'react';
import { Link } from 'react-router-dom';
import { Question } from './interfaces';

export default function QuestionPage({ question, addComment }: { question: Question, addComment(id: number, answer: string): void }): ReactElement {

  const [pendingAnswer, setPendingAnswer] = useState('');

  const {
    author,
    answers,
    creationDate,
    id,
    title,
    viewsCount,
    content
  } = question;

  function onClickAdd() {
    if (pendingAnswer.trim()) {
      addComment(id, pendingAnswer);
      setPendingAnswer('');
    }
  }

  return (
    <>
      <h2>{title}</h2>
      <Link to="/">Back</Link>
      <div>
        Author: <strong>{author}</strong>
      </div>
      <div>
        Views: <strong>{viewsCount}</strong>
      </div>
      <div>
        Date: <strong>{creationDate.toString()}</strong>
      </div>
      <p>
        Details: {content}
      </p>

      <p>
        <label>
          Add answer:
        <input value={pendingAnswer} onChange={evt => setPendingAnswer((evt.target as any).value)} />
        </label>
        <button type="button" onClick={() => onClickAdd()}>Add</button>
      </p>

      <div>
        Answers:
        <ol>
          {answers.map((answer, idx) => <li key={idx}>{answer}</li>)}
        </ol>
      </div>
    </>
  );
}