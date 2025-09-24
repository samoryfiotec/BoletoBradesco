# BoletoBradesco

Geração de boletos bancários do Bradesco com .NET 8 utilizando Clean Architecture e bibliotecas modernas como **BoletoNetCore**, **iText** e **ZXing.Net**.

Este projeto demonstra como estruturar uma aplicação robusta e testável para emissão de boletos, com foco em qualidade de código, separação de responsabilidades e geração de PDFs profissionais.

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-red)](https://dotnet.microsoft.com/)
![GitHub repo size](https://img.shields.io/github/repo-size/samoryfiotec/BoletoBradesco?label=Repo%20Size&color=brown&style=flat&suffix=KB)
[![BoletoNetCore](https://img.shields.io/badge/BoletoNetCore-3.0.1.485-blue)](https://github.com/boleto-net/boletonetcore)
[![ZXing.Net](https://img.shields.io/badge/ZXing.Net-0.16.10-teal)](https://github.com/micjahn/ZXing.Net)
[![iText](https://img.shields.io/badge/iText-orange)](https://github.com/)

## Recursos

- Layout HTML de boletos Bradesco com código de barras
- Geração de boleto em PDF com **iText**
- Geração de código de barras com **ZXing.Net**
- Arquitetura Limpa (Clean Architecture)
- Testes automatizados com **xUnit**
- Compatível com .NET 8

## Instalação

Adicione os pacotes via NuGet:

```bash
dotnet add package BoletoNetCore
dotnet add package ZXing.Net
dotnet add package iText
```

### Licença

Este repositório está sob a licença [MIT](LICENSE.txt)