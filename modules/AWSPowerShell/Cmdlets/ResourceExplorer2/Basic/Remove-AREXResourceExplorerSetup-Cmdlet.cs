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
    /// Deletes a Resource Explorer setup configuration. This operation removes indexes and
    /// views from the specified Regions or all Regions where Resource Explorer is configured.
    /// </summary>
    [Cmdlet("Remove", "AREXResourceExplorerSetup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Explorer DeleteResourceExplorerSetup API operation.", Operation = new[] {"DeleteResourceExplorerSetup"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse))]
    [AWSCmdletOutput("System.String or Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveAREXResourceExplorerSetupCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteInAllRegion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to delete Resource Explorer configuration from all Regions where
        /// it is currently enabled. If this parameter is set to <c>true</c>, a value for <c>RegionList</c>
        /// must not be provided. Otherwise, the operation fails with a <c>ValidationException</c>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteInAllRegions")]
        public System.Boolean? DeleteInAllRegion { get; set; }
        #endregion
        
        #region Parameter RegionList
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services Regions from which to delete the Resource Explorer configuration.
        /// If not specified, the operation uses the <c>DeleteInAllRegions</c> parameter to determine
        /// scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RegionList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AREXResourceExplorerSetup (DeleteResourceExplorerSetup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse, RemoveAREXResourceExplorerSetupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteInAllRegion = this.DeleteInAllRegion;
            if (this.RegionList != null)
            {
                context.RegionList = new List<System.String>(this.RegionList);
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
            var request = new Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupRequest();
            
            if (cmdletContext.DeleteInAllRegion != null)
            {
                request.DeleteInAllRegions = cmdletContext.DeleteInAllRegion.Value;
            }
            if (cmdletContext.RegionList != null)
            {
                request.RegionList = cmdletContext.RegionList;
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
        
        private Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "DeleteResourceExplorerSetup");
            try
            {
                #if DESKTOP
                return client.DeleteResourceExplorerSetup(request);
                #elif CORECLR
                return client.DeleteResourceExplorerSetupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteInAllRegion { get; set; }
            public List<System.String> RegionList { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.DeleteResourceExplorerSetupResponse, RemoveAREXResourceExplorerSetupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
