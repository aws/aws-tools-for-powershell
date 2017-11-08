/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Disassociates a node from a Chef server, and removes the node from the Chef server's
    /// managed nodes. After a node is disassociated, the node key pair is no longer valid
    /// for accessing the Chef API. For more information about how to associate a node, see
    /// <a>AssociateNode</a>. 
    /// 
    ///  
    /// <para>
    /// A node can can only be disassociated from a server that is in a <code>HEALTHY</code>
    /// state. Otherwise, an <code>InvalidStateException</code> is thrown. A <code>ResourceNotFoundException</code>
    /// is thrown when the server does not exist. A <code>ValidationException</code> is raised
    /// when parameters of the request are not valid. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "OWCMNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS OpsWorksCM DisassociateNode API operation.", Operation = new[] {"DisassociateNode"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.OpsWorksCM.Model.DisassociateNodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveOWCMNodeCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        #region Parameter EngineAttribute
        /// <summary>
        /// <para>
        /// Amazon.OpsWorksCM.Model.DisassociateNodeRequest.EngineAttributes
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EngineAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] EngineAttribute { get; set; }
        #endregion
        
        #region Parameter NodeName
        /// <summary>
        /// <para>
        /// <para>The name of the Chef client node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NodeName { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server from which to disassociate the node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-OWCMNode (DisassociateNode)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.EngineAttribute != null)
            {
                context.EngineAttributes = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.EngineAttribute);
            }
            context.NodeName = this.NodeName;
            context.ServerName = this.ServerName;
            
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
            var request = new Amazon.OpsWorksCM.Model.DisassociateNodeRequest();
            
            if (cmdletContext.EngineAttributes != null)
            {
                request.EngineAttributes = cmdletContext.EngineAttributes;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NodeAssociationStatusToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.OpsWorksCM.Model.DisassociateNodeResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.DisassociateNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "DisassociateNode");
            try
            {
                #if DESKTOP
                return client.DisassociateNode(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DisassociateNodeAsync(request);
                return task.Result;
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
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> EngineAttributes { get; set; }
            public System.String NodeName { get; set; }
            public System.String ServerName { get; set; }
        }
        
    }
}
