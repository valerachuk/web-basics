import React, { ReactElement } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { Question } from './interfaces';
import { useForm } from "react-hook-form";



export default function QuestionForm({ addQuestion }: { addQuestion(q: Question): void }): ReactElement {

  const { register, handleSubmit, errors } = useForm();
  const history = useHistory();

  function onSubmit(data: Partial<Question>) {
    const additionalData: Partial<Question> = {
      answers: [],
      creationDate: new Date().toString(),
      id: new Date().getTime(),
      viewsCount: 0
    };

    addQuestion({ ...data, ...additionalData } as Question);
    history.push('/');
  }

  return (
    <>
      <h2>Ask Question</h2>
      <Link to="/">
        <p>Back</p>
      </Link>
      <form onSubmit={handleSubmit(onSubmit)}>
        <p>
          <label>
            Name
            &nbsp;
          <input name="author" ref={register({ required: true })} />
          </label>
        </p>
        <p>
          <label>
            Title
            &nbsp;
          <input name="title" ref={register({ required: true })} />
          </label>
        </p>
        <p>
          <label>
            Content
            &nbsp;
          <textarea name="content" ref={register({ required: true })} />
          </label>
        </p>
        {Object.keys(errors).length !== 0 &&
          <p style={{ color: 'red' }}>
            Please, fill the fields
         </p>}
        <button type="submit">Submit</button>
      </form>
    </>
  );
}
