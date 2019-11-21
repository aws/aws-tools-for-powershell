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
using Amazon.ServiceQuotas;
using Amazon.ServiceQuotas.Model;

namespace Amazon.PowerShell.Cmdlets.SQ
{
    /// <summary>
    /// Defines and adds a quota to the service quota template. To add a quota to the template,
    /// you must provide the <code>ServiceCode</code>, <code>QuotaCode</code>, <code>AwsRegion</code>,
    /// and <code>DesiredValue</code>. Once you add a quota to the template, use <a>ListServiceQuotaIncreaseRequestsInTemplate</a>
    /// to see the list of quotas in the template.
    /// </summary>
    [Cmdlet("Write", "SQServiceQuotaIncreaseRequestIntoTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceQuotas.Model.ServiceQuotaIncreaseRequestInTemplate")]
    [AWSCmdlet("Calls the AWS Service Quotas PutServiceQuotaIncreaseRequestIntoTemplate API operation.", Operation = new[] {"PutServiceQuotaIncreaseRequestIntoTemplate"}, SelectReturnType = typeof(Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse))]
    [AWSCmdletOutput("Amazon.ServiceQuotas.Model.ServiceQuotaIncreaseRequestInTemplate or Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse",
        "This cmdlet returns an Amazon.ServiceQuotas.Model.ServiceQuotaIncreaseRequestInTemplate object.",
        "The service call response (type Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSQServiceQuotaIncreaseRequestIntoTemplateCmdlet : AmazonServiceQuotasClientCmdlet, IExecutor
    {
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// <para>Specifies the AWS Region for the quota. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsRegion { get; set; }
        #endregion
        
        #region Parameter DesiredValue
        /// <summary>
        /// <para>
        /// <para>Specifies the new, increased value for the quota. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? DesiredValue { get; set; }
        #endregion
        
        #region Parameter QuotaCode
        /// <summary>
        /// <para>
        /// <para>Specifies the service quota that you want to use.</para>
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
        public System.String QuotaCode { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>Specifies the service that you want to use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceQuotaIncreaseRequestInTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse).
        /// Specifying the name of a property of type Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceQuotaIncreaseRequestInTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QuotaCode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QuotaCode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QuotaCode' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QuotaCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SQServiceQuotaIncreaseRequestIntoTemplate (PutServiceQuotaIncreaseRequestIntoTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse, WriteSQServiceQuotaIncreaseRequestIntoTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QuotaCode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsRegion = this.AwsRegion;
            #if MODULAR
            if (this.AwsRegion == null && ParameterWasBound(nameof(this.AwsRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DesiredValue = this.DesiredValue;
            #if MODULAR
            if (this.DesiredValue == null && ParameterWasBound(nameof(this.DesiredValue)))
            {
                WriteWarning("You are passing $null as a value for parameter DesiredValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QuotaCode = this.QuotaCode;
            #if MODULAR
            if (this.QuotaCode == null && ParameterWasBound(nameof(this.QuotaCode)))
            {
                WriteWarning("You are passing $null as a value for parameter QuotaCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceCode = this.ServiceCode;
            #if MODULAR
            if (this.ServiceCode == null && ParameterWasBound(nameof(this.ServiceCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateRequest();
            
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegion = cmdletContext.AwsRegion;
            }
            if (cmdletContext.DesiredValue != null)
            {
                request.DesiredValue = cmdletContext.DesiredValue.Value;
            }
            if (cmdletContext.QuotaCode != null)
            {
                request.QuotaCode = cmdletContext.QuotaCode;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCode = cmdletContext.ServiceCode;
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
        
        private Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse CallAWSServiceOperation(IAmazonServiceQuotas client, Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Quotas", "PutServiceQuotaIncreaseRequestIntoTemplate");
            try
            {
                #if DESKTOP
                return client.PutServiceQuotaIncreaseRequestIntoTemplate(request);
                #elif CORECLR
                return client.PutServiceQuotaIncreaseRequestIntoTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsRegion { get; set; }
            public System.Double? DesiredValue { get; set; }
            public System.String QuotaCode { get; set; }
            public System.String ServiceCode { get; set; }
            public System.Func<Amazon.ServiceQuotas.Model.PutServiceQuotaIncreaseRequestIntoTemplateResponse, WriteSQServiceQuotaIncreaseRequestIntoTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceQuotaIncreaseRequestInTemplate;
        }
        
    }
}
