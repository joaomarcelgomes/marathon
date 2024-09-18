import classnames from 'classnames'

export interface TextareaProps extends React.ComponentProps<'textarea'> {
  height?: number
  children?: React.ReactNode
}

export const Textarea: React.FC<TextareaProps> = ({
  style,
  height = 150,
  children,
  className,
  ...rest
}) => {
  return (
    <div className="custom-textarea form-group rounded shadow">
      <textarea
        style={{ height, ...style }}
        className={classnames(
          'form-control form-control-lg bg-none border-0',
          className
        )}
        {...rest}
      >
        {children}
      </textarea>
    </div>
  )
}
