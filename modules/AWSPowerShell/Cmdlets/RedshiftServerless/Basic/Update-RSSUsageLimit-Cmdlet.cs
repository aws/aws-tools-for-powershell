/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Update a usage limit in Amazon Redshift Serverless. You can't update the usage type
    /// or period of a usage limit.
    /// </summary>
    [Cmdlet("Update", "RSSUsageLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.UsageLimit")]
    [AWSCmdlet("Calls the Redshift Serverless UpdateUsageLimit API operation.", Operation = new[] {"UpdateUsageLimit"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.UsageLimit or Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.UsageLimit object.",
        "The service call response (type Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateRSSUsageLimitCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Amount
        /// <summary>
        /// <para>
        /// <para>The new limit amount. If time-based, this amount is in Redshift Processing Units (RPU)
        /// consumed per hour. If data-based, this amount is in terabytes (TB) of data transferred
        /// between Regions in cross-account sharing. The value must be a positive number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Amount { get; set; }
        #endregion
        
        #region Parameter BreachAction
        /// <summary>
        /// <para>
        /// <para>The new action that Amazon Redshift Serverless takes when the limit is reached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.UsageLimitBreachAction")]
        public Amazon.RedshiftServerless.UsageLimitBreachAction BreachAction { get; set; }
        #endregion
        
        #region Parameter UsageLimitId
        /// <summary>
        /// <para>
        /// <para>The identifier of the usage limit to update.</para>
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
        public System.String UsageLimitId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UsageLimit'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UsageLimit";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UsageLimitId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UsageLimitId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UsageLimitId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UsageLimitId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSUsageLimit (UpdateUsageLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse, UpdateRSSUsageLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UsageLimitId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Amount = this.Amount;
            context.BreachAction = this.BreachAction;
            context.UsageLimitId = this.UsageLimitId;
            #if MODULAR
            if (this.UsageLimitId == null && ParameterWasBound(nameof(this.UsageLimitId)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageLimitId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.UpdateUsageLimitRequest();
            
            if (cmdletContext.Amount != null)
            {
                request.Amount = cmdletContext.Amount.Value;
            }
            if (cmdletContext.BreachAction != null)
            {
                request.BreachAction = cmdletContext.BreachAction;
            }
            if (cmdletContext.UsageLimitId != null)
            {
                request.UsageLimitId = cmdletContext.UsageLimitId;
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
        
        private Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateUsageLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "UpdateUsageLimit");
            try
            {
                #if DESKTOP
                return client.UpdateUsageLimit(request);
                #elif CORECLR
                return client.UpdateUsageLimitAsync(request).GetAwaiter().GetResult();
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
            public System.String UsageLimitId { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateUsageLimitResponse, UpdateRSSUsageLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UsageLimit;
        }
        
    }
}
