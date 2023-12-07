import { CodeSnippet } from "src/components/code-snippet";
import LabForm from "src/components/lab-form";
import { PageLayout } from "src/components/page-layout";
import { useLabResult } from "src/hooks/useLabResult";

const Lab3Page: React.FC = () => {
  const { result, getResult } = useLabResult(3);

  return (
    <PageLayout>
      <div className="content-layout">
        <h1
          id="page-title"
          className="content__title"
        >
          Лабораторна робота 3
        </h1>
        <div className="content__body">
          <p>
          Недавно Билл устроился на работу полицейским. Теперь ему предстоит каждый вечер обходить свой участок, который представляет собой прямоугольник, состоящий из N×M кварталов. Каждый квартал имеет вид квадрата размером 100 х 100 метров, кварталы отделены друг от друга прямыми улицами.
        Таким образом, через участок Билла проходит N+1 улица, идущая с запада на восток, и M+1 улица, идущая с севера на юг. Перекрестки разбивают улицы на (N+1)*M + (M+1)*N отрезков, каждый из которых имеет длину 100 метров.
        Совершая обход, Билл выходит из полицейского управления, расположенного около юго-западного угла его участка, обходит свой участок и возвращается в управление. Во время обхода Билл должен пройти по каждому отрезку улицы на территории своего участка как минимум один раз. Известно, что во время обхода Билл проходит отрезок длиной 100 метров за одну минуту. Выясните, какое минимальное число минут потребуется Биллу, чтобы совершить обход.
        Входные данные
        Входной файл INPUT.TXT содержит натуральные числа N и M, не превышающие 10 000.
        Выходные данные
        В выходной файл OUTPUT.TXT выведите минимальное время, за которое Билл может совершить обход.

          </p>
          <h3 className="content__title">Приклад файлу введення:</h3>
          <p id="page-description">
            <span></span>
          </p>
          <h3 className="content__title">Приклад файлу виведення:</h3>
          <p id="page-description">
            <span></span>
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

export default Lab3Page;
