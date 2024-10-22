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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates a usage limit for a specified Amazon Redshift feature on a cluster. The usage
    /// limit is identified by the returned usage limit identifier.
    /// </summary>
    [Cmdlet("New", "RSUsageLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.CreateUsageLimitResponse")]
    [AWSCmdlet("Calls the Amazon Redshift CreateUsageLimit API operation.", Operation = new[] {"CreateUsageLimit"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateUsageLimitResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.CreateUsageLimitResponse",
        "This cmdlet returns an Amazon.Redshift.Model.CreateUsageLimitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSUsageLimitCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Amount
        /// <summary>
        /// <para>
        /// <para>The limit amount. If time-based, this amount is in minutes. If data-based, this amount
        /// is in terabytes (TB). The value must be a positive number. </para>
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
        /// <para>The action that Amazon Redshift takes when the limit is reached. The default is log.
        /// For more information about this parameter, see <a>UsageLimit</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitBreachAction")]
        public Amazon.Redshift.UsageLimitBreachAction BreachAction { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster that you want to limit usage.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter FeatureType
        /// <summary>
        /// <para>
        /// <para>The Amazon Redshift feature that you want to limit.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitFeatureType")]
        public Amazon.Redshift.UsageLimitFeatureType FeatureType { get; set; }
        #endregion
        
        #region Parameter LimitType
        /// <summary>
        /// <para>
        /// <para>The type of limit. Depending on the feature type, this can be based on a time duration
        /// or data size. If <c>FeatureType</c> is <c>spectrum</c>, then <c>LimitType</c> must
        /// be <c>data-scanned</c>. If <c>FeatureType</c> is <c>concurrency-scaling</c>, then
        /// <c>LimitType</c> must be <c>time</c>. If <c>FeatureType</c> is <c>cross-region-datasharing</c>,
        /// then <c>LimitType</c> must be <c>data-scanned</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitLimitType")]
        public Amazon.Redshift.UsageLimitLimitType LimitType { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The time period that the amount applies to. A <c>weekly</c> period begins on Sunday.
        /// The default is <c>monthly</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitPeriod")]
        public Amazon.Redshift.UsageLimitPeriod Period { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateUsageLimitResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateUsageLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSUsageLimit (CreateUsageLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateUsageLimitResponse, NewRSUsageLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Amount = this.Amount;
            #if MODULAR
            if (this.Amount == null && ParameterWasBound(nameof(this.Amount)))
            {
                WriteWarning("You are passing $null as a value for parameter Amount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BreachAction = this.BreachAction;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FeatureType = this.FeatureType;
            #if MODULAR
            if (this.FeatureType == null && ParameterWasBound(nameof(this.FeatureType)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LimitType = this.LimitType;
            #if MODULAR
            if (this.LimitType == null && ParameterWasBound(nameof(this.LimitType)))
            {
                WriteWarning("You are passing $null as a value for parameter LimitType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Period = this.Period;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Redshift.Model.CreateUsageLimitRequest();
            
            if (cmdletContext.Amount != null)
            {
                request.Amount = cmdletContext.Amount.Value;
            }
            if (cmdletContext.BreachAction != null)
            {
                request.BreachAction = cmdletContext.BreachAction;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.FeatureType != null)
            {
                request.FeatureType = cmdletContext.FeatureType;
            }
            if (cmdletContext.LimitType != null)
            {
                request.LimitType = cmdletContext.LimitType;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Redshift.Model.CreateUsageLimitResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateUsageLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateUsageLimit");
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
            public Amazon.Redshift.UsageLimitBreachAction BreachAction { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public Amazon.Redshift.UsageLimitFeatureType FeatureType { get; set; }
            public Amazon.Redshift.UsageLimitLimitType LimitType { get; set; }
            public Amazon.Redshift.UsageLimitPeriod Period { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateUsageLimitResponse, NewRSUsageLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
