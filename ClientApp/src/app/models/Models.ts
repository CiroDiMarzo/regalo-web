

export interface QuestionModel {
    id: number;
    imageUrl: string;
    question: string;
    options: Array<OptionModel>;
    givenAnswer: AnswerModel;
    responseMessage: string;
  }
  
  export interface OptionModel {
    id: number,
    title: string
  }
  
  export interface AnswerModel {
    questionId: number;
    optionId: string;
    title?: string;
    isCorrect?: boolean | undefined;
  }
  
  export interface AnswerResultModel {
    isCorrect: boolean;
    message: string;
  }
  
  export interface GiftModel {
    title: string;
    description: string;
    pictureUrl: string;
    contentUrl: string;
  }
  
  export interface ValidationResult {
    isValid: boolean;
    message: string;
    giftList: GiftModel[]
  }
  
  export interface ConfigurationModel {
    targetFolder: string;
  }