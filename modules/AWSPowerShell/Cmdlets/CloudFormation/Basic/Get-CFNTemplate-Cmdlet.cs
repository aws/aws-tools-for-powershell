/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns the template body for a specified stack. You can get the template for running
    /// or deleted stacks.
    /// 
    ///  
    /// <para>
    /// For deleted stacks, <code>GetTemplate</code> returns the template for up to 90 days
    /// after the stack has been deleted.
    /// </para><note><para>
    /// If the template doesn't exist, a <code>ValidationError</code> is returned.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFNTemplate")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation GetTemplate API operation.", Operation = new[] {"GetTemplate"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.GetTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.GetTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.GetTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNTemplateCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of a change set for which CloudFormation returns
        /// the associated template. If you specify a name, you must also specify the <code>StackName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the unique stack ID that's associated with the stack, which aren't always
        /// interchangeable:</para><ul><li><para>Running stacks: You can specify either the stack's name or its unique stack ID.</para></li><li><para>Deleted stacks: You must specify the unique stack ID.</para></li></ul><para>Default: There is no default value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter TemplateStage
        /// <summary>
        /// <para>
        /// <para>For templates that include transforms, the stage of the template that CloudFormation
        /// returns. To get the user-submitted template, specify <code>Original</code>. To get
        /// the template after CloudFormation has processed all transforms, specify <code>Processed</code>.</para><para>If the template doesn't include transforms, <code>Original</code> and <code>Processed</code>
        /// return the same template. By default, CloudFormation specifies <code>Processed</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.TemplateStage")]
        public Amazon.CloudFormation.TemplateStage TemplateStage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TemplateBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.GetTemplateResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.GetTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TemplateBody";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.GetTemplateResponse, GetCFNTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChangeSetName = this.ChangeSetName;
            context.StackName = this.StackName;
            context.TemplateStage = this.TemplateStage;
            
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
            var request = new Amazon.CloudFormation.Model.GetTemplateRequest();
            
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.TemplateStage != null)
            {
                request.TemplateStage = cmdletContext.TemplateStage;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CloudFormation.Model.GetTemplateResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.GetTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "GetTemplate");
            try
            {
                #if DESKTOP
                return client.GetTemplate(request);
                #elif CORECLR
                return client.GetTemplateAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ChangeSetName { get; set; }
            public System.String StackName { get; set; }
            public Amazon.CloudFormation.TemplateStage TemplateStage { get; set; }
            public System.Func<Amazon.CloudFormation.Model.GetTemplateResponse, GetCFNTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TemplateBody;
        }
        
    }
}
