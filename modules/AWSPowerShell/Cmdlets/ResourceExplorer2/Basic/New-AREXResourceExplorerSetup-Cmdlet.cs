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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Creates a Resource Explorer setup configuration across multiple Amazon Web Services
    /// Regions. This operation sets up indexes and views in the specified Regions. This operation
    /// can also be used to set an aggregator Region for cross-Region resource search.
    /// </summary>
    [Cmdlet("New", "AREXResourceExplorerSetup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Explorer CreateResourceExplorerSetup API operation.", Operation = new[] {"CreateResourceExplorerSetup"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse))]
    [AWSCmdletOutput("System.String or Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAREXResourceExplorerSetupCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregatorRegion
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services Regions that should be configured as aggregator Regions.
        /// Aggregator Regions receive replicated index information from all other Regions where
        /// there is a user-owned index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregatorRegions")]
        public System.String[] AggregatorRegion { get; set; }
        #endregion
        
        #region Parameter RegionList
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services Regions where Resource Explorer should be configured.
        /// Each Region in the list will have a user-owned index created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] RegionList { get; set; }
        #endregion
        
        #region Parameter ViewName
        /// <summary>
        /// <para>
        /// <para>The name for the view to be created as part of the Resource Explorer setup. The view
        /// name must be unique within the Amazon Web Services account and Region.</para>
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
        public System.String ViewName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AREXResourceExplorerSetup (CreateResourceExplorerSetup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse, NewAREXResourceExplorerSetupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AggregatorRegion != null)
            {
                context.AggregatorRegion = new List<System.String>(this.AggregatorRegion);
            }
            if (this.RegionList != null)
            {
                context.RegionList = new List<System.String>(this.RegionList);
            }
            #if MODULAR
            if (this.RegionList == null && ParameterWasBound(nameof(this.RegionList)))
            {
                WriteWarning("You are passing $null as a value for parameter RegionList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ViewName = this.ViewName;
            #if MODULAR
            if (this.ViewName == null && ParameterWasBound(nameof(this.ViewName)))
            {
                WriteWarning("You are passing $null as a value for parameter ViewName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupRequest();
            
            if (cmdletContext.AggregatorRegion != null)
            {
                request.AggregatorRegions = cmdletContext.AggregatorRegion;
            }
            if (cmdletContext.RegionList != null)
            {
                request.RegionList = cmdletContext.RegionList;
            }
            if (cmdletContext.ViewName != null)
            {
                request.ViewName = cmdletContext.ViewName;
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
        
        private Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "CreateResourceExplorerSetup");
            try
            {
                #if DESKTOP
                return client.CreateResourceExplorerSetup(request);
                #elif CORECLR
                return client.CreateResourceExplorerSetupAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AggregatorRegion { get; set; }
            public List<System.String> RegionList { get; set; }
            public System.String ViewName { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.CreateResourceExplorerSetupResponse, NewAREXResourceExplorerSetupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
