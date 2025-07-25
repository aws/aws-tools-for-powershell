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
using System.Threading;
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Gets the availability options configured for a domain. By default, shows the configuration
    /// with any pending changes. Set the <c>Deployed</c> option to <c>true</c> to show the
    /// active configuration and exclude pending changes. For more information, see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-availability-options.html" target="_blank">Configuring Availability Options</a> in the <i>Amazon CloudSearch
    /// Developer Guide</i>.
    /// </summary>
    [Cmdlet("Get", "CSAvailabilityOption")]
    [OutputType("Amazon.CloudSearch.Model.AvailabilityOptionsStatus")]
    [AWSCmdlet("Calls the Amazon CloudSearch DescribeAvailabilityOptions API operation.", Operation = new[] {"DescribeAvailabilityOptions"}, SelectReturnType = typeof(Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse), LegacyAlias="Get-CSAvailabilityOptions")]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.AvailabilityOptionsStatus or Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse",
        "This cmdlet returns an Amazon.CloudSearch.Model.AvailabilityOptionsStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCSAvailabilityOptionCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Deployed
        /// <summary>
        /// <para>
        /// <para>Whether to display the deployed configuration (<c>true</c>) or include any pending
        /// changes (<c>false</c>). Defaults to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Deployed { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain you want to describe.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AvailabilityOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse).
        /// Specifying the name of a property of type Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AvailabilityOptions";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse, GetCSAvailabilityOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Deployed = this.Deployed;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudSearch.Model.DescribeAvailabilityOptionsRequest();
            
            if (cmdletContext.Deployed != null)
            {
                request.Deployed = cmdletContext.Deployed.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
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
        
        private Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DescribeAvailabilityOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DescribeAvailabilityOptions");
            try
            {
                return client.DescribeAvailabilityOptionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Deployed { get; set; }
            public System.String DomainName { get; set; }
            public System.Func<Amazon.CloudSearch.Model.DescribeAvailabilityOptionsResponse, GetCSAvailabilityOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AvailabilityOptions;
        }
        
    }
}
