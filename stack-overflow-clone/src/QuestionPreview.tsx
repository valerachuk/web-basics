import React, { ReactElement } from 'react';
import { Link } from 'react-router-dom';
import { Question } from './interfaces';

export default function QuestionPreview({ question, incrementQuestionVisits }: { question: Question, incrementQuestionVisits(id: number): void }): ReactElement {

  const {
    author,
    answers,
    creationDate,
    id,
    title,
    viewsCount
  } = question;

  return (
    <div className="question-review-container">
      <Link onClick={() => incrementQuestionVisits(id)} to={`/question/${id}`} >
        <h3>
          {title}
        </h3>
      </Link>
      <div>
        Author: <strong>{author}</strong>
      </div>
      <div>
        Answers: <strong>{answers.length}</strong>
      </div>
      <div>
        Views: <strong>{viewsCount}</strong>
      </div>
      <div>
        Date: <strong>{creationDate.toString()}</strong>
      </div>
    </div>
  );
}