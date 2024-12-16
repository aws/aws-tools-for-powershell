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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Update the OpenSearch Serverless settings for the current Amazon Web Services account.
    /// For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-scaling.html">Managing
    /// capacity limits for Amazon OpenSearch Serverless</a>.
    /// </summary>
    [Cmdlet("Update", "OSSAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.AccountSettingsDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.AccountSettingsDetail or Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.AccountSettingsDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSSAccountSettingCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityLimits_MaxIndexingCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The maximum indexing capacity for collections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityLimits_MaxIndexingCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter CapacityLimits_MaxSearchCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The maximum search capacity for collections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityLimits_MaxSearchCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountSettingsDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountSettingsDetail";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSSAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse, UpdateOSSAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityLimits_MaxIndexingCapacityInOCU = this.CapacityLimits_MaxIndexingCapacityInOCU;
            context.CapacityLimits_MaxSearchCapacityInOCU = this.CapacityLimits_MaxSearchCapacityInOCU;
            
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
            var request = new Amazon.OpenSearchServerless.Model.UpdateAccountSettingsRequest();
            
            
             // populate CapacityLimits
            var requestCapacityLimitsIsNull = true;
            request.CapacityLimits = new Amazon.OpenSearchServerless.Model.CapacityLimits();
            System.Int32? requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MaxIndexingCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU = cmdletContext.CapacityLimits_MaxIndexingCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU != null)
            {
                request.CapacityLimits.MaxIndexingCapacityInOCU = requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
            System.Int32? requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MaxSearchCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU = cmdletContext.CapacityLimits_MaxSearchCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU != null)
            {
                request.CapacityLimits.MaxSearchCapacityInOCU = requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
             // determine if request.CapacityLimits should be set to null
            if (requestCapacityLimitsIsNull)
            {
                request.CapacityLimits = null;
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
        
        private Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "UpdateAccountSettings");
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
            public System.Int32? CapacityLimits_MaxIndexingCapacityInOCU { get; set; }
            public System.Int32? CapacityLimits_MaxSearchCapacityInOCU { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.UpdateAccountSettingsResponse, UpdateOSSAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountSettingsDetail;
        }
        
    }
}
