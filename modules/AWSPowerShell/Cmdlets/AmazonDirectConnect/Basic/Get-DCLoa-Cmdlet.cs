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
    /// Returns the LOA-CFA for a connection, interconnect, or link aggregation group (LAG).
    /// 
    ///  
    /// <para>
    /// The Letter of Authorization - Connecting Facility Assignment (LOA-CFA) is a document
    /// that is used when establishing your cross connect to AWS at the colocation facility.
    /// For more information, see <a href="http://docs.aws.amazon.com/directconnect/latest/UserGuide/Colocation.html">Requesting
    /// Cross Connects at AWS Direct Connect Locations</a> in the AWS Direct Connect user
    /// guide.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DCLoa")]
    [OutputType("Amazon.DirectConnect.Model.DescribeLoaResponse")]
    [AWSCmdlet("Invokes the DescribeLoa operation against AWS Direct Connect.", Operation = new[] {"DescribeLoa"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DescribeLoaResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.DescribeLoaResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDCLoaCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of a connection, LAG, or interconnect for which to get the LOA-CFA information.</para><para>Example: dxcon-abc123 or dxlag-abc123</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter LoaContentType
        /// <summary>
        /// <para>
        /// <para>A standard media type indicating the content type of the LOA-CFA document. Currently,
        /// the only supported value is "application/pdf".</para><para>Default: application/pdf</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.LoaContentType")]
        public Amazon.DirectConnect.LoaContentType LoaContentType { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the service provider who establishes connectivity on your behalf. If you
        /// supply this parameter, the LOA-CFA lists the provider name alongside your company
        /// name as the requester of the cross connect.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProviderName { get; set; }
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
            context.LoaContentType = this.LoaContentType;
            context.ProviderName = this.ProviderName;
            
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
            var request = new Amazon.DirectConnect.Model.DescribeLoaRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.LoaContentType != null)
            {
                request.LoaContentType = cmdletContext.LoaContentType;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
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
        
        private Amazon.DirectConnect.Model.DescribeLoaResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeLoaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DescribeLoa");
            try
            {
                #if DESKTOP
                return client.DescribeLoa(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeLoaAsync(request);
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
            public Amazon.DirectConnect.LoaContentType LoaContentType { get; set; }
            public System.String ProviderName { get; set; }
        }
        
    }
}
