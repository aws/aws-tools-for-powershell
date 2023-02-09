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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Creates a standby WorkSpace in a secondary Region.
    /// </summary>
    [Cmdlet("New", "WKSStandbyWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse")]
    [AWSCmdlet("Calls the Amazon WorkSpaces CreateStandbyWorkspaces API operation.", Operation = new[] {"CreateStandbyWorkspaces"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWKSStandbyWorkspaceCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter PrimaryRegion
        /// <summary>
        /// <para>
        /// <para>The Region of the primary WorkSpace.</para>
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
        public System.String PrimaryRegion { get; set; }
        #endregion
        
        #region Parameter StandbyWorkspace
        /// <summary>
        /// <para>
        /// <para>Information about the standby WorkSpace to be created.</para>
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
        [Alias("StandbyWorkspaces")]
        public Amazon.WorkSpaces.Model.StandbyWorkspace[] StandbyWorkspace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrimaryRegion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrimaryRegion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrimaryRegion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrimaryRegion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WKSStandbyWorkspace (CreateStandbyWorkspaces)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse, NewWKSStandbyWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrimaryRegion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PrimaryRegion = this.PrimaryRegion;
            #if MODULAR
            if (this.PrimaryRegion == null && ParameterWasBound(nameof(this.PrimaryRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StandbyWorkspace != null)
            {
                context.StandbyWorkspace = new List<Amazon.WorkSpaces.Model.StandbyWorkspace>(this.StandbyWorkspace);
            }
            #if MODULAR
            if (this.StandbyWorkspace == null && ParameterWasBound(nameof(this.StandbyWorkspace)))
            {
                WriteWarning("You are passing $null as a value for parameter StandbyWorkspace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.CreateStandbyWorkspacesRequest();
            
            if (cmdletContext.PrimaryRegion != null)
            {
                request.PrimaryRegion = cmdletContext.PrimaryRegion;
            }
            if (cmdletContext.StandbyWorkspace != null)
            {
                request.StandbyWorkspaces = cmdletContext.StandbyWorkspace;
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
        
        private Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.CreateStandbyWorkspacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "CreateStandbyWorkspaces");
            try
            {
                #if DESKTOP
                return client.CreateStandbyWorkspaces(request);
                #elif CORECLR
                return client.CreateStandbyWorkspacesAsync(request).GetAwaiter().GetResult();
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
            public System.String PrimaryRegion { get; set; }
            public List<Amazon.WorkSpaces.Model.StandbyWorkspace> StandbyWorkspace { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.CreateStandbyWorkspacesResponse, NewWKSStandbyWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
