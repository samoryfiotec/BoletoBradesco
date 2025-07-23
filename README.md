# BoletoBradesco

Geração de boletos bancários do Bradesco com .NET 8/9 utilizando Clean Architecture e bibliotecas modernas como **BoletoNetCore**, **DinkToPdf** e **ZXing.Net**.

Este projeto demonstra como estruturar uma aplicação robusta e testável para emissão de boletos, com foco em qualidade de código, separação de responsabilidades e geração de PDFs profissionais.

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-red)](https://dotnet.microsoft.com/)
![GitHub repo size](https://img.shields.io/github/repo-size/samoryfiotec/BoletoBradesco?label=Repo%20Size&color=brown&style=flat&suffix=KB)

## Recursos

- Geração de boletos Bradesco com código de barras
- Layout de boleto em PDF com **DinkToPdf**
- Geração de código de barras com **ZXing.Net**
- Arquitetura Limpa (Clean Architecture)
- Testes automatizados com **xUnit**
- Compatível com .NET 8 e 9

## Instalação

Adicione os pacotes via NuGet:

```bash
dotnet add package BoletoNetCore
dotnet add package ZXing.Net
dotnet add package DinkToPdf
```

### Licença

Este repo está sob a licença [MIT](LICENSE.txt)