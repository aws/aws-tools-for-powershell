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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns information about the last resize operation for the specified cluster. If
    /// no resize operation has ever been initiated for the specified cluster, a <code>HTTP
    /// 404</code> error is returned. If a resize operation was initiated and completed, the
    /// status of the resize remains as <code>SUCCEEDED</code> until the next resize. 
    /// 
    ///  
    /// <para>
    /// A resize operation can be requested using <a>ModifyCluster</a> and specifying a different
    /// number or type of nodes for the cluster. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSResize")]
    [OutputType("Amazon.Redshift.Model.DescribeResizeResponse")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeResize API operation.", Operation = new[] {"DescribeResize"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.DescribeResizeResponse",
        "This cmdlet returns a Amazon.Redshift.Model.DescribeResizeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSResizeCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a cluster whose resize progress you are requesting. This
        /// parameter is case-sensitive.</para><para>By default, resize operations for all clusters defined for an AWS account are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
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
            
            context.ClusterIdentifier = this.ClusterIdentifier;
            
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
            var request = new Amazon.Redshift.Model.DescribeResizeRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
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
        
        private Amazon.Redshift.Model.DescribeResizeResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeResizeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeResize");
            try
            {
                #if DESKTOP
                return client.DescribeResize(request);
                #elif CORECLR
                return client.DescribeResizeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
        }
        
    }
}
