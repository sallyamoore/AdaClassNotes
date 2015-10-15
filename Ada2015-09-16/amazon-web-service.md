# AWS

# Capstone request
- Host using a VPS such as Amazon EC2
- Use background jobs for any long running tasks
- Config DNS with custom domain
- Use caching for slow or bulky db
- Integrate email
...

can do all with AWS

# Scenario: task
A rails app needs to do a long-running task (E.g., image upload with multiple sizes etc) in response to a user action   
  - Creates a latency that users hate.

Solution: Message Queue
- Decouple components of program
- Asynchronous communication: it's a text msg, not a phone call.
- xxx

100x faster

# Activity: speaker/listener. WHOA.
https://github.com/philipmw/ada-messaging

# AWS costs
- AWS is a la carte, with costs increasing proportionally with usage.
- Develop an intuition for AWS costs by checking various scenarios in the AWS simple monthly calculator.
- AWS can incur unlimited charges. NEVER share credentials with ppl, particularly NEVER share with the Internet.

# SNS - Simple Notification Service.
Allows you to have broadcast functionality - replicate every message to any number of endpoints.
Endpoints can be SQS, SMS, email, and more.
Cool!

see https://github.com/philipmw/ada-chat

# Example final project ideas using this stuff
- Web-based chat(SNS + SQS)
- Internet-based Jukebox (SQS)
- Utility company with dynamic pricing (SNS)

# Databases in AWS
Services > RDS
Instances > Launch DB Instance
  - note that this charges by the INSTANCE, even if you don't use it.

Select engine >
Production?  - if will be used in production, creates 2 copies in case one fails
etc

when done, will give a host name (endpoint), which you can plug into Rails app to migrate etc

# EC2 - Virtual machine on one of Amazon's servers.
Building an EC2 instance means creating one virtual machine. EC2 stands for Elastic Computing Cloud. Virtualized computer on amazons hardware that you have access to.

Services > EC2
Instances > Launch
Amazon Linux is usually a good option for OS
Review and launch

public IP address lets you ssh into host. From location of your key (mine is in samo-ada/ada-samo.pem)
`$ ssh -i ada-samo.pem ec2-user@52.26.132.131`

-> warning that it's not secure enough. So increase security!
`$ chmod 600 ada-samo.pem`

then do it again:
`$ ssh -i ada-samo.pem ec2-user@52.26.132.131`

To delete instance:
Instances > Actions > Terminate
EVERYTHING would be gone

Can also stop instance, which won't delete it. But you also won't be charged while its stopped.
Instances > Actions > stop

# Other services that might be useful
DynamoDB, a scalable NoSQL database
S3, object storage
API Gateway + Lambda,


# AWS educate
access to info, labs, etc.
AWS self-paced labs - can get certified as an AWS dev, can play with pieces of AWS without paying. Yay!
