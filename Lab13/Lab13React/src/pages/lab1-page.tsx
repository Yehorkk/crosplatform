import { CodeSnippet } from "src/components/code-snippet";
import LabForm from "src/components/lab-form";
import { PageLayout } from "src/components/page-layout";
import { useLabResult } from "src/hooks/useLabResult";

const Lab1Page: React.FC = () => {
  const { result, getResult } = useLabResult(1);

  return (
    <PageLayout>
      <div className="content-layout">
        <h1
          id="page-title"
          className="content__title"
        >
          Лабораторна робота 1
        </h1>
        <div className="content__body">
          <p id="page-description">
            <span>
            Вариант 58
        У Вас есть N камней с массами W1, W2 , … WN. Требуется разложить камни на 2 кучки так,
        чтобы разница масс этих кучек была минимальной.
        Входные данные
        В первой строке входного файла INPUT.TXT записано число N – количество камней (1 ≤ N ≤ 18).
        Во второй строке через пробел перечислены массы камней W1, W2 , … WN (1 ≤ Wi ≤ 105).
        Выходные данные
        В единственную строку выходного файла OUTPUT.TXT нужно вывести одно
        неотрицательное целое число – минимально возможную разницу между массами
        двух кучек.
            </span>
          </p>
          <h3 className="content__title">Приклад вхідних данних:</h3>
          <p id="page-description">
            <span>
            5
            5 8 13 27 14
              <br />
            </span>
          </p>
          <h3 className="content__title">Приклад данних після роботи програми:</h3>
          <p id="page-description">
            <span>5 8 13 27 14</span>
          </p>

          <LabForm submitHandler={getResult} />
          <CodeSnippet
            title="Результат:"
            code={result}
          />
        </div>
      </div>
    </PageLayout>
  );
};

export default Lab1Page;
