# AI Text Analyzer API (.NET)

API em .NET que utiliza IA para analisar textos e gerar automaticamente:

- resumo do texto
- palavras-chave

O projeto foi criado como estudo de integração de **LLMs (Large Language Models)** com **ASP.NET Web API**.

---

## 🚀 Tecnologias utilizadas

- .NET 9
- ASP.NET Web API
- HttpClient
- System.Text.Json
- Swagger
- HuggingFace AI API

---

## 🧠 Como funciona

O usuário envia um texto para a API.

Exemplo de requisição:

POST /api/text/analisar

```json
{
  "texto": "O Censo Agropecuário realizado pelo IBGE é uma das principais fontes de informação sobre a estrutura produtiva do campo brasileiro. A pesquisa coleta dados sobre o número de estabelecimentos rurais, tamanho das propriedades, tipos de culturas plantadas, produção de alimentos, uso de máquinas agrícolas, sistemas de irrigação e utilização de insumos como fertilizantes e defensivos. Além disso, o levantamento também analisa aspectos sociais, como mão de obra empregada no campo, participação da agricultura familiar e acesso a crédito rural. Esses dados são fundamentais para orientar políticas públicas, apoiar pesquisas acadêmicas e permitir que governos e instituições compreendam melhor as dinâmicas econômicas e sociais da agropecuária no Brasil. Ao longo dos anos, o Censo Agropecuário tem permitido identificar mudanças importantes no uso da terra, no aumento da produtividade e na adoção de novas tecnologias no campo."
}
```
Resposta da API:
```json
{
  "resumo": "O Censo Agropecuário do IBGE coleta informações detalhadas sobre a estrutura produtiva e social do campo brasileiro, incluindo número e tamanho dos estabelecimentos rurais, tipos de culturas, produção, uso de máquinas, irrigação, insumos, mão de obra, agricultura familiar e acesso a crédito. Esses dados orientam políticas públicas, pesquisas acadêmicas e a compreensão das dinâmicas econômicas e sociais da agropecuária, permitindo monitorar mudanças no uso da terra, produtividade e adoção de tecnologias.",
  "palavrasChave": [
    "Censo Agropecuário",
    "IBGE",
    "agricultura familiar",
    "produção agrícola",
    "políticas públicas"
  ]
}
