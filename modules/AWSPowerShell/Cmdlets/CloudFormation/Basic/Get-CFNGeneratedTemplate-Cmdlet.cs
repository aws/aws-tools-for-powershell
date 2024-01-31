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
    /// Retrieves a generated template. If the template is in an <c>InProgress</c> or <c>Pending</c>
    /// status then the template returned will be the template when the template was last
    /// in a <c>Complete</c> status. If the template has not yet been in a <c>Complete</c>
    /// status then an empty template will be returned.
    /// </summary>
    [Cmdlet("Get", "CFNGeneratedTemplate")]
    [OutputType("Amazon.CloudFormation.Model.GetGeneratedTemplateResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation GetGeneratedTemplate API operation.", Operation = new[] {"GetGeneratedTemplate"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.GetGeneratedTemplateResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.GetGeneratedTemplateResponse",
        "This cmdlet returns an Amazon.CloudFormation.Model.GetGeneratedTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNGeneratedTemplateCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The language to use to retrieve for the generated template. Supported values are:</para><ul><li><para><c>JSON</c></para></li><li><para><c>YAML</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.TemplateFormat")]
        public Amazon.CloudFormation.TemplateFormat Format { get; set; }
        #endregion
        
        #region Parameter GeneratedTemplateName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the generated template. The format is <c>arn:${Partition}:cloudformation:${Region}:${Account}:generatedtemplate/${Id}</c>.
        /// For example, <c>arn:aws:cloudformation:<i>us-east-1</i>:<i>123456789012</i>:generatedtemplate/<i>2e8465c1-9a80-43ea-a3a3-4f2d692fe6dc</i></c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GeneratedTemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.GetGeneratedTemplateResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.GetGeneratedTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GeneratedTemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GeneratedTemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GeneratedTemplateName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.GetGeneratedTemplateResponse, GetCFNGeneratedTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GeneratedTemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Format = this.Format;
            context.GeneratedTemplateName = this.GeneratedTemplateName;
            #if MODULAR
            if (this.GeneratedTemplateName == null && ParameterWasBound(nameof(this.GeneratedTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter GeneratedTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFormation.Model.GetGeneratedTemplateRequest();
            
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.GeneratedTemplateName != null)
            {
                request.GeneratedTemplateName = cmdletContext.GeneratedTemplateName;
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
        
        private Amazon.CloudFormation.Model.GetGeneratedTemplateResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.GetGeneratedTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "GetGeneratedTemplate");
            try
            {
                #if DESKTOP
                return client.GetGeneratedTemplate(request);
                #elif CORECLR
                return client.GetGeneratedTemplateAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudFormation.TemplateFormat Format { get; set; }
            public System.String GeneratedTemplateName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.GetGeneratedTemplateResponse, GetCFNGeneratedTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
