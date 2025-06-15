import { Meta, StoryObj } from '@storybook/angular';

import { ButtonComponent } from './button.component';

const meta: Meta<ButtonComponent> = {
  title: 'Shared UI/Primary Button',
  component: ButtonComponent,
  tags: ['autodocs'],
  argTypes: {
    clicked: { action: 'clicked' }
  }
};

export default meta;

type Story = StoryObj<ButtonComponent>;

export const Coworking: Story = {
  args: {
    label: 'View details',
  },
};

export const Workspace: Story = {
  args: {
    label: 'Book now',
  },
};