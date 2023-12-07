import React, { useState } from "react";

interface LabFormProps {
  submitHandler: (inputPath: string, outputPath: string) => void;
}

const LabForm: React.FC<LabFormProps> = ({ submitHandler }) => {
  const [input, setInput] = useState<string>("");
  const [output, setOutput] = useState<string>("");

  return (
    <>
      <h3 className="content__title">Заповніть інформацію про шляхи</h3>
      <form
        onSubmit={(event) => {
          event.preventDefault();
          submitHandler(input, output);
        }}
      >
        <label className="content__title">
          Input шлях:
          <br />
          <input
            type="text"
            value={input}
            onChange={(event) => {
              setInput(event.target.value);
            }}
          />
        </label>
        <br />
        <label className="content__title">
          Outputh шлях:
          <br />
          <input
            type="text"
            value={output}
            onChange={(event) => {
              setOutput(event.target.value);
            }}
          />
        </label>
        <br />
        <input
          type="submit"
          value="Submit"
        />
      </form>
    </>
  );
};

export default LabForm;
