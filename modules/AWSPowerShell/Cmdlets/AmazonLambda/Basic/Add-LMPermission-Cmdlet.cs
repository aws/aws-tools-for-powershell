/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Adds a permission to the resource policy associated with the specified AWS Lambda
    /// function. You use resource policies to grant permissions to event sources that use
    /// <i>push</i> model. In a <i>push</i> model, event sources (such as Amazon S3 and custom
    /// applications) invoke your Lambda function. Each permission you add to the resource
    /// policy allows an event source, permission to invoke the Lambda function. 
    /// 
    ///  
    /// <para>
    /// For information about the push model, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/lambda-introduction.html">AWS
    /// Lambda: How it Works</a>. 
    /// </para><para>
    /// If you are using versioning, the permissions you add are specific to the Lambda function
    /// version or alias you specify in the <code>AddPermission</code> request via the <code>Qualifier</code>
    /// parameter. For more information about versioning, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>. 
    /// </para><para>
    /// This operation requires permission for the <code>lambda:AddPermission</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "LMPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the AddPermission operation against Amazon Lambda.", Operation = new[] {"AddPermission"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Lambda.Model.AddPermissionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddLMPermissionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The AWS Lambda action you want to allow in this statement. Each Lambda action is a
        /// string starting with <code>lambda:</code> followed by the API name . For example,
        /// <code>lambda:CreateFunction</code>. You can use wildcard (<code>lambda:*</code>) to
        /// grant permission for all AWS Lambda actions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter EventSourceToken
        /// <summary>
        /// <para>
        /// <para>A unique token that must be supplied by the principal invoking the function. This
        /// is currently only used for Alexa Smart Home functions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventSourceToken { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>Name of the Lambda function whose resource policy you are updating by adding a new
        /// permission.</para><para> You can specify a function name (for example, <code>Thumbnail</code>) or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, <code>arn:aws:lambda:us-west-2:account-id:function:ThumbNail</code>).
        /// AWS Lambda also allows you to specify partial ARN (for example, <code>account-id:Thumbnail</code>).
        /// Note that the length constraint applies only to the ARN. If you specify only the function
        /// name, it is limited to 64 characters in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principal who is getting this permission. It can be Amazon S3 service Principal
        /// (<code>s3.amazonaws.com</code>) if you want Amazon S3 to invoke the function, an AWS
        /// account ID if you are granting cross-account permission, or any valid AWS service
        /// principal such as <code>sns.amazonaws.com</code>. For example, you might want to allow
        /// a custom application in another AWS account to push events to AWS Lambda by invoking
        /// your function. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>You can use this optional query parameter to describe a qualified ARN using a function
        /// version or an alias name. The permission will then apply to the specific qualified
        /// ARN. For example, if you specify function version 2 as the qualifier, then permission
        /// applies only when request is made using qualified function ARN:</para><para><code>arn:aws:lambda:aws-region:acct-id:function:function-name:2</code></para><para>If you specify an alias name, for example <code>PROD</code>, then the permission is
        /// valid only for requests made using the alias ARN:</para><para><code>arn:aws:lambda:aws-region:acct-id:function:function-name:PROD</code></para><para>If the qualifier is not specified, the permission is valid only when requests is made
        /// using unqualified function ARN.</para><para><code>arn:aws:lambda:aws-region:acct-id:function:function-name</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter SourceAccount
        /// <summary>
        /// <para>
        /// <para>This parameter is used for S3 and SES. The AWS account ID (without a hyphen) of the
        /// source owner. For example, if the <code>SourceArn</code> identifies a bucket, then
        /// this is the bucket owner's account ID. You can use this additional condition to ensure
        /// the bucket you specify is owned by a specific account (it is possible the bucket owner
        /// deleted the bucket and some other AWS account created the bucket). You can also use
        /// this condition to specify all sources (that is, you don't specify the <code>SourceArn</code>)
        /// owned by a specific account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceAccount { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>This is optional; however, when granting permission to invoke your function, you should
        /// specify this field with the Amazon Resource Name (ARN) as its value. This ensures
        /// that only events generated from the specified source can invoke the function.</para><important><para>If you add a permission without providing the source ARN, any AWS account that creates
        /// a mapping to your function ARN can send events to invoke your Lambda function.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>A unique statement identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LMPermission (AddPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Action = this.Action;
            context.EventSourceToken = this.EventSourceToken;
            context.FunctionName = this.FunctionName;
            context.Principal = this.Principal;
            context.Qualifier = this.Qualifier;
            context.SourceAccount = this.SourceAccount;
            context.SourceArn = this.SourceArn;
            context.StatementId = this.StatementId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.AddPermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.EventSourceToken != null)
            {
                request.EventSourceToken = cmdletContext.EventSourceToken;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
            }
            if (cmdletContext.SourceAccount != null)
            {
                request.SourceAccount = cmdletContext.SourceAccount;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.StatementId != null)
            {
                request.StatementId = cmdletContext.StatementId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Statement;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.AddPermissionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.AddPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lambda", "AddPermission");
            #if DESKTOP
            return client.AddPermission(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddPermissionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Action { get; set; }
            public System.String EventSourceToken { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Principal { get; set; }
            public System.String Qualifier { get; set; }
            public System.String SourceAccount { get; set; }
            public System.String SourceArn { get; set; }
            public System.String StatementId { get; set; }
        }
        
    }
}
