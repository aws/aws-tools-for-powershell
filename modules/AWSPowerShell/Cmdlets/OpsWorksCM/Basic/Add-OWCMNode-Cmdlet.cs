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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Associates a new node with the server. For more information about how to disassociate
    /// a node, see <a>DisassociateNode</a>.
    /// 
    ///  
    /// <para>
    ///  On a Chef server: This command is an alternative to <c>knife bootstrap</c>.
    /// </para><para>
    ///  Example (Chef): <c>aws opsworks-cm associate-node --server-name <i>MyServer</i> --node-name
    /// <i>MyManagedNode</i> --engine-attributes "Name=<i>CHEF_ORGANIZATION</i>,Value=default"
    /// "Name=<i>CHEF_NODE_PUBLIC_KEY</i>,Value=<i>public-key-pem</i>"</c></para><para>
    ///  On a Puppet server, this command is an alternative to the <c>puppet cert sign</c>
    /// command that signs a Puppet node CSR. 
    /// </para><para>
    ///  Example (Puppet): <c>aws opsworks-cm associate-node --server-name <i>MyServer</i>
    /// --node-name <i>MyManagedNode</i> --engine-attributes "Name=<i>PUPPET_NODE_CSR</i>,Value=<i>csr-pem</i>"</c></para><para>
    ///  A node can can only be associated with servers that are in a <c>HEALTHY</c> state.
    /// Otherwise, an <c>InvalidStateException</c> is thrown. A <c>ResourceNotFoundException</c>
    /// is thrown when the server does not exist. A <c>ValidationException</c> is raised when
    /// parameters of the request are not valid. The AssociateNode API call can be integrated
    /// into Auto Scaling configurations, AWS Cloudformation templates, or the user data of
    /// a server's instance. 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "OWCMNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS OpsWorksCM AssociateNode API operation.", Operation = new[] {"AssociateNode"}, SelectReturnType = typeof(Amazon.OpsWorksCM.Model.AssociateNodeResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpsWorksCM.Model.AssociateNodeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpsWorksCM.Model.AssociateNodeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddOWCMNodeCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EngineAttribute
        /// <summary>
        /// <para>
        /// <para>Engine attributes used for associating the node. </para><para><b>Attributes accepted in a AssociateNode request for Chef</b></para><ul><li><para><c>CHEF_ORGANIZATION</c>: The Chef organization with which the node is associated.
        /// By default only one organization named <c>default</c> can exist. </para></li><li><para><c>CHEF_NODE_PUBLIC_KEY</c>: A PEM-formatted public key. This key is required for
        /// the <c>chef-client</c> agent to access the Chef API. </para></li></ul><para><b>Attributes accepted in a AssociateNode request for Puppet</b></para><ul><li><para><c>PUPPET_NODE_CSR</c>: A PEM-formatted certificate-signing request (CSR) that is
        /// created by the node. </para></li></ul>
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
        [Alias("EngineAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] EngineAttribute { get; set; }
        #endregion
        
        #region Parameter NodeName
        /// <summary>
        /// <para>
        /// <para>The name of the node. </para>
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
        public System.String NodeName { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server with which to associate the node. </para>
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
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NodeAssociationStatusToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorksCM.Model.AssociateNodeResponse).
        /// Specifying the name of a property of type Amazon.OpsWorksCM.Model.AssociateNodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NodeAssociationStatusToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-OWCMNode (AssociateNode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorksCM.Model.AssociateNodeResponse, AddOWCMNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EngineAttribute != null)
            {
                context.EngineAttribute = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.EngineAttribute);
            }
            #if MODULAR
            if (this.EngineAttribute == null && ParameterWasBound(nameof(this.EngineAttribute)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineAttribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeName = this.NodeName;
            #if MODULAR
            if (this.NodeName == null && ParameterWasBound(nameof(this.NodeName)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerName = this.ServerName;
            #if MODULAR
            if (this.ServerName == null && ParameterWasBound(nameof(this.ServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpsWorksCM.Model.AssociateNodeRequest();
            
            if (cmdletContext.EngineAttribute != null)
            {
                request.EngineAttributes = cmdletContext.EngineAttribute;
            }
            if (cmdletContext.NodeName != null)
            {
                request.NodeName = cmdletContext.NodeName;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
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
        
        private Amazon.OpsWorksCM.Model.AssociateNodeResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.AssociateNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "AssociateNode");
            try
            {
                #if DESKTOP
                return client.AssociateNode(request);
                #elif CORECLR
                return client.AssociateNodeAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> EngineAttribute { get; set; }
            public System.String NodeName { get; set; }
            public System.String ServerName { get; set; }
            public System.Func<Amazon.OpsWorksCM.Model.AssociateNodeResponse, AddOWCMNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NodeAssociationStatusToken;
        }
        
    }
}
