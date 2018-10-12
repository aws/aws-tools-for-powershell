/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a link aggregation group (LAG) with the specified number of bundled physical
    /// connections between the customer network and a specific AWS Direct Connect location.
    /// A LAG is a logical interface that uses the Link Aggregation Control Protocol (LACP)
    /// to aggregate multiple interfaces, enabling you to treat them as a single interface.
    /// 
    ///  
    /// <para>
    /// All connections in a LAG must use the same bandwidth and must terminate at the same
    /// AWS Direct Connect endpoint.
    /// </para><para>
    /// You can have up to 10 connections per LAG. Regardless of this limit, if you request
    /// more connections for the LAG than AWS Direct Connect can allocate on a single endpoint,
    /// no LAG is created.
    /// </para><para>
    /// You can specify an existing physical connection or interconnect to include in the
    /// LAG (which counts towards the total number of connections). Doing so interrupts the
    /// current physical connection or hosted connections, and re-establishes them as a member
    /// of the LAG. The LAG will be created on the same AWS Direct Connect endpoint to which
    /// the connection terminates. Any virtual interfaces associated with the connection are
    /// automatically disassociated and re-associated with the LAG. The connection ID does
    /// not change.
    /// </para><para>
    /// If the AWS account used to create a LAG is a registered AWS Direct Connect partner,
    /// the LAG is automatically enabled to host sub-connections. For a LAG owned by a partner,
    /// any associated virtual interfaces cannot be directly configured.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCLag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreateLagResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateLag API operation.", Operation = new[] {"CreateLag"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreateLagResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.CreateLagResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCLagCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing connection to migrate to the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter ConnectionsBandwidth
        /// <summary>
        /// <para>
        /// <para>The bandwidth of the individual physical connections bundled by the LAG. The possible
        /// values are 1Gbps and 10Gbps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionsBandwidth { get; set; }
        #endregion
        
        #region Parameter LagName
        /// <summary>
        /// <para>
        /// <para>The name of the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LagName { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The location for the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter NumberOfConnection
        /// <summary>
        /// <para>
        /// <para>The number of physical connections initially provisioned and bundled by the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumberOfConnections")]
        public System.Int32 NumberOfConnection { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConnectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCLag (CreateLag)"))
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
            
            context.ConnectionId = this.ConnectionId;
            context.ConnectionsBandwidth = this.ConnectionsBandwidth;
            context.LagName = this.LagName;
            context.Location = this.Location;
            if (ParameterWasBound("NumberOfConnection"))
                context.NumberOfConnections = this.NumberOfConnection;
            
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
            var request = new Amazon.DirectConnect.Model.CreateLagRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.ConnectionsBandwidth != null)
            {
                request.ConnectionsBandwidth = cmdletContext.ConnectionsBandwidth;
            }
            if (cmdletContext.LagName != null)
            {
                request.LagName = cmdletContext.LagName;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.NumberOfConnections != null)
            {
                request.NumberOfConnections = cmdletContext.NumberOfConnections.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.DirectConnect.Model.CreateLagResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateLagRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateLag");
            try
            {
                #if DESKTOP
                return client.CreateLag(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLagAsync(request);
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
            public System.String ConnectionId { get; set; }
            public System.String ConnectionsBandwidth { get; set; }
            public System.String LagName { get; set; }
            public System.String Location { get; set; }
            public System.Int32? NumberOfConnections { get; set; }
        }
        
    }
}
