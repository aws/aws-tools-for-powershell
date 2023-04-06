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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Get counts of Proton resources.
    /// 
    ///  
    /// <para>
    /// For infrastructure-provisioning resources (environments, services, service instances,
    /// pipelines), the action returns staleness counts. A resource is stale when it's behind
    /// the recommended version of the Proton template that it uses and it needs an update
    /// to become current.
    /// </para><para>
    /// The action returns staleness counts (counts of resources that are up-to-date, behind
    /// a template major version, or behind a template minor version), the total number of
    /// resources, and the number of resources that are in a failed state, grouped by resource
    /// type. Components, environments, and service templates return less information - see
    /// the <code>components</code>, <code>environments</code>, and <code>serviceTemplates</code>
    /// field descriptions.
    /// </para><para>
    /// For context, the action also returns the total number of each type of Proton template
    /// in the Amazon Web Services account.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/monitoring-dashboard.html">Proton
    /// dashboard</a> in the <i>Proton User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PROResourcesSummary")]
    [OutputType("Amazon.Proton.Model.CountsSummary")]
    [AWSCmdlet("Calls the AWS Proton GetResourcesSummary API operation.", Operation = new[] {"GetResourcesSummary"}, SelectReturnType = typeof(Amazon.Proton.Model.GetResourcesSummaryResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.CountsSummary or Amazon.Proton.Model.GetResourcesSummaryResponse",
        "This cmdlet returns an Amazon.Proton.Model.CountsSummary object.",
        "The service call response (type Amazon.Proton.Model.GetResourcesSummaryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPROResourcesSummaryCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Counts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.GetResourcesSummaryResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.GetResourcesSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Counts";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.GetResourcesSummaryResponse, GetPROResourcesSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Proton.Model.GetResourcesSummaryRequest();
            
            
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
        
        private Amazon.Proton.Model.GetResourcesSummaryResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.GetResourcesSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "GetResourcesSummary");
            try
            {
                #if DESKTOP
                return client.GetResourcesSummary(request);
                #elif CORECLR
                return client.GetResourcesSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Proton.Model.GetResourcesSummaryResponse, GetPROResourcesSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Counts;
        }
        
    }
}
