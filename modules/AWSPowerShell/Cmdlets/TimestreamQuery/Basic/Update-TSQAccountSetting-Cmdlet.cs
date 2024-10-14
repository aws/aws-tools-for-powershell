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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// Transitions your account to use TCUs for query pricing and modifies the maximum query
    /// compute units that you've configured. If you reduce the value of <c>MaxQueryTCU</c>
    /// to a desired configuration, the new value can take up to 24 hours to be effective.
    /// 
    ///  <note><para>
    /// After you've transitioned your account to use TCUs for query pricing, you can't transition
    /// to using bytes scanned for query pricing.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "TSQAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Timestream Query UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse object containing multiple properties."
    )]
    public partial class UpdateTSQAccountSettingCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxQueryTCU
        /// <summary>
        /// <para>
        /// <para>The maximum number of compute units the service will use at any point in time to serve
        /// your queries. To run queries, you must set a minimum capacity of 4 TCU. You can set
        /// the maximum number of TCU in multiples of 4, for example, 4, 8, 16, 32, and so on.</para><para>The maximum value supported for <c>MaxQueryTCU</c> is 1000. To request an increase
        /// to this soft limit, contact Amazon Web Services Support. For information about the
        /// default quota for maxQueryTCU, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html#limits.default">Default
        /// quotas</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Int32? MaxQueryTCU { get; set; }
        #endregion
        
        #region Parameter QueryPricingModel
        /// <summary>
        /// <para>
        /// <para>The pricing model for queries in an account.</para><note><para>The <c>QueryPricingModel</c> parameter is used by several Timestream operations; however,
        /// the <c>UpdateAccountSettings</c> API operation doesn't recognize any values other
        /// than <c>COMPUTE_UNITS</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamQuery.QueryPricingModel")]
        public Amazon.TimestreamQuery.QueryPricingModel QueryPricingModel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MaxQueryTCU parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MaxQueryTCU' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MaxQueryTCU' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MaxQueryTCU), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TSQAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse, UpdateTSQAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MaxQueryTCU;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxQueryTCU = this.MaxQueryTCU;
            context.QueryPricingModel = this.QueryPricingModel;
            
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
            var request = new Amazon.TimestreamQuery.Model.UpdateAccountSettingsRequest();
            
            if (cmdletContext.MaxQueryTCU != null)
            {
                request.MaxQueryTCU = cmdletContext.MaxQueryTCU.Value;
            }
            if (cmdletContext.QueryPricingModel != null)
            {
                request.QueryPricingModel = cmdletContext.QueryPricingModel;
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
        
        private Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "UpdateAccountSettings");
            try
            {
                #if DESKTOP
                return client.UpdateAccountSettings(request);
                #elif CORECLR
                return client.UpdateAccountSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxQueryTCU { get; set; }
            public Amazon.TimestreamQuery.QueryPricingModel QueryPricingModel { get; set; }
            public System.Func<Amazon.TimestreamQuery.Model.UpdateAccountSettingsResponse, UpdateTSQAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
