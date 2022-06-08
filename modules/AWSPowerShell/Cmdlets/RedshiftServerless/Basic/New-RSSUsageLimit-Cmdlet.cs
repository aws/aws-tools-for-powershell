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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Creates a usage limit for a specified Amazon Redshift Serverless usage type. The usage
    /// limit is identified by the returned usage limit identifier.
    /// </summary>
    [Cmdlet("New", "RSSUsageLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.UsageLimit")]
    [AWSCmdlet("Calls the Amazon Redshift Serverless CreateUsageLimit API operation.", Operation = new[] {"CreateUsageLimit"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.CreateUsageLimitResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.UsageLimit or Amazon.RedshiftServerless.Model.CreateUsageLimitResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.UsageLimit object.",
        "The service call response (type Amazon.RedshiftServerless.Model.CreateUsageLimitResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSSUsageLimitCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        #region Parameter Amount
        /// <summary>
        /// <para>
        /// <para>The limit amount. If time-based, this amount is in Redshift Processing Units (RPU)
        /// consumed per hour. If data-based, this amount is in terabytes (TB) of data transferred
        /// between Regions in cross-account sharing. The value must be a positive number.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? Amount { get; set; }
        #endregion
        
        #region Parameter BreachAction
        /// <summary>
        /// <para>
        /// <para>The action that Amazon Redshift Serverless takes when the limit is reached. The default
        /// is log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.UsageLimitBreachAction")]
        public Amazon.RedshiftServerless.UsageLimitBreachAction BreachAction { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The time period that the amount applies to. A weekly period begins on Sunday. The
        /// default is monthly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.UsageLimitPeriod")]
        public Amazon.RedshiftServerless.UsageLimitPeriod Period { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Redshift Serverless resource to create
        /// the usage limit for.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter UsageType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Redshift Serverless usage to create a usage limit for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RedshiftServerless.UsageLimitUsageType")]
        public Amazon.RedshiftServerless.UsageLimitUsageType UsageType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UsageLimit'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.CreateUsageLimitResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.CreateUsageLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UsageLimit";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSUsageLimit (CreateUsageLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.CreateUsageLimitResponse, NewRSSUsageLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Amount = this.Amount;
            #if MODULAR
            if (this.Amount == null && ParameterWasBound(nameof(this.Amount)))
            {
                WriteWarning("You are passing $null as a value for parameter Amount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BreachAction = this.BreachAction;
            context.Period = this.Period;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UsageType = this.UsageType;
            #if MODULAR
            if (this.UsageType == null && ParameterWasBound(nameof(this.UsageType)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.CreateUsageLimitRequest();
            
            if (cmdletContext.Amount != null)
            {
                request.Amount = cmdletContext.Amount.Value;
            }
            if (cmdletContext.BreachAction != null)
            {
                request.BreachAction = cmdletContext.BreachAction;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.UsageType != null)
            {
                request.UsageType = cmdletContext.UsageType;
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
        
        private Amazon.RedshiftServerless.Model.CreateUsageLimitResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.CreateUsageLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift Serverless", "CreateUsageLimit");
            try
            {
                #if DESKTOP
                return client.CreateUsageLimit(request);
                #elif CORECLR
                return client.CreateUsageLimitAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? Amount { get; set; }
            public Amazon.RedshiftServerless.UsageLimitBreachAction BreachAction { get; set; }
            public Amazon.RedshiftServerless.UsageLimitPeriod Period { get; set; }
            public System.String ResourceArn { get; set; }
            public Amazon.RedshiftServerless.UsageLimitUsageType UsageType { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.CreateUsageLimitResponse, NewRSSUsageLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UsageLimit;
        }
        
    }
}
