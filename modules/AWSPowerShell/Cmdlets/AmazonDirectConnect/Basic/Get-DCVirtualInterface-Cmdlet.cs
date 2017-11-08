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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Displays all virtual interfaces for an AWS account. Virtual interfaces deleted fewer
    /// than 15 minutes before you make the request are also returned. If you specify a connection
    /// ID, only the virtual interfaces associated with the connection are returned. If you
    /// specify a virtual interface ID, then only a single virtual interface is returned.
    /// 
    ///  
    /// <para>
    /// A virtual interface (VLAN) transmits the traffic between the AWS Direct Connect location
    /// and the customer.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DCVirtualInterface")]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Calls the AWS Direct Connect DescribeVirtualInterfaces API operation.", Operation = new[] {"DescribeVirtualInterfaces"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface",
        "This cmdlet returns a collection of VirtualInterface objects.",
        "The service call response (type Amazon.DirectConnect.Model.DescribeVirtualInterfacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDCVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConnectionId = this.ConnectionId;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            
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
            var request = new Amazon.DirectConnect.Model.DescribeVirtualInterfacesRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VirtualInterfaces;
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
        
        private Amazon.DirectConnect.Model.DescribeVirtualInterfacesResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeVirtualInterfacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DescribeVirtualInterfaces");
            try
            {
                #if DESKTOP
                return client.DescribeVirtualInterfaces(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVirtualInterfacesAsync(request);
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
            public System.String VirtualInterfaceId { get; set; }
        }
        
    }
}
