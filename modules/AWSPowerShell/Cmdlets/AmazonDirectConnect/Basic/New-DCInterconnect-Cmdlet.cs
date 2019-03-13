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
    /// Creates an interconnect between an AWS Direct Connect Partner's network and a specific
    /// AWS Direct Connect location.
    /// 
    ///  
    /// <para>
    /// An interconnect is a connection that is capable of hosting other connections. The
    /// AWS Direct Connect partner can use an interconnect to provide AWS Direct Connect hosted
    /// connections to customers through their own network services. Like a standard connection,
    /// an interconnect links the partner's network to an AWS Direct Connect location over
    /// a standard Ethernet fiber-optic cable. One end is connected to the partner's router,
    /// the other to an AWS Direct Connect router.
    /// </para><para>
    /// You can automatically add the new interconnect to a link aggregation group (LAG) by
    /// specifying a LAG ID in the request. This ensures that the new interconnect is allocated
    /// on the same AWS Direct Connect endpoint that hosts the specified LAG. If there are
    /// no available ports on the endpoint, the request fails and no interconnect is created.
    /// </para><para>
    /// For each end customer, the AWS Direct Connect Partner provisions a connection on their
    /// interconnect by calling <a>AllocateHostedConnection</a>. The end customer can then
    /// connect to AWS resources by creating a virtual interface on their connection, using
    /// the VLAN assigned to them by the AWS Direct Connect Partner.
    /// </para><note><para>
    /// Intended for use by AWS Direct Connect Partners only.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "DCInterconnect", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreateInterconnectResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateInterconnect API operation.", Operation = new[] {"CreateInterconnect"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreateInterconnectResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.CreateInterconnectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCInterconnectCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Bandwidth
        /// <summary>
        /// <para>
        /// <para>The port bandwidth, in Gbps. The possible values are 1 and 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Bandwidth { get; set; }
        #endregion
        
        #region Parameter InterconnectName
        /// <summary>
        /// <para>
        /// <para>The name of the interconnect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String InterconnectName { get; set; }
        #endregion
        
        #region Parameter LagId
        /// <summary>
        /// <para>
        /// <para>The ID of the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LagId { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The location of the interconnect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Location { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InterconnectName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCInterconnect (CreateInterconnect)"))
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
            
            context.Bandwidth = this.Bandwidth;
            context.InterconnectName = this.InterconnectName;
            context.LagId = this.LagId;
            context.Location = this.Location;
            
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
            var request = new Amazon.DirectConnect.Model.CreateInterconnectRequest();
            
            if (cmdletContext.Bandwidth != null)
            {
                request.Bandwidth = cmdletContext.Bandwidth;
            }
            if (cmdletContext.InterconnectName != null)
            {
                request.InterconnectName = cmdletContext.InterconnectName;
            }
            if (cmdletContext.LagId != null)
            {
                request.LagId = cmdletContext.LagId;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
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
        
        private Amazon.DirectConnect.Model.CreateInterconnectResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateInterconnectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateInterconnect");
            try
            {
                #if DESKTOP
                return client.CreateInterconnect(request);
                #elif CORECLR
                return client.CreateInterconnectAsync(request).GetAwaiter().GetResult();
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
            public System.String Bandwidth { get; set; }
            public System.String InterconnectName { get; set; }
            public System.String LagId { get; set; }
            public System.String Location { get; set; }
        }
        
    }
}
