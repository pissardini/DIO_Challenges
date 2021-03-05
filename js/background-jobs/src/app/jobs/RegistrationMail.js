import Mail from '../lib/Mail';

export default {
  key: 'RegistrationMail',
  async handle({ data }) {
    const { user } = data;

    await Mail.sendMail({
      from: 'DIO <contato@dio.com.br>',
      to: `${user.name} <${user.email}>`,
      subject: 'Cadastro de usuário',
      html: `Olá, ${user.name}, bem-vindo ao nosso sistema.`
    });
  },
};