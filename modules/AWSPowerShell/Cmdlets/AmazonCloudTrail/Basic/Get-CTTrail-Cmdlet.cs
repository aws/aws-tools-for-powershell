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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Retrieves settings for the trail associated with the current region for your account.
    /// </summary>
    [Cmdlet("Get", "CTTrail")]
    [OutputType("Amazon.CloudTrail.Model.Trail")]
    [AWSCmdlet("Invokes the DescribeTrails operation against AWS CloudTrail.", Operation = new[] {"DescribeTrails"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.Trail",
        "This cmdlet returns a collection of Trail objects.",
        "The service call response (type Amazon.CloudTrail.Model.DescribeTrailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCTTrailCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeShadowTrail
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include shadow trails in the response. A shadow trail is the
        /// replication in a region of a trail that was created in a different region. The default
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("IncludeShadowTrails")]
        public System.Boolean IncludeShadowTrail { get; set; }
        #endregion
        
        #region Parameter TrailNameList
        /// <summary>
        /// <para>
        /// <para>Specifies a list of trail names, trail ARNs, or both, of the trails to describe. The
        /// format of a trail ARN is:</para><para><code>arn:aws:cloudtrail:us-east-1:123456789012:trail/MyTrail</code></para><para>If an empty list is specified, information for the trail in the current region is
        /// returned.</para><ul><li><para>If an empty list is specified and <code>IncludeShadowTrails</code> is false, then
        /// information for all trails in the current region is returned.</para></li><li><para>If an empty list is specified and IncludeShadowTrails is null or true, then information
        /// for all trails in the current region and any associated shadow trails in other regions
        /// is returned.</para></li></ul><note><para>If one or more trail names are specified, information is returned only if the names
        /// match the names of trails belonging only to the current region. To return information
        /// about a trail in another region, you must specify its trail ARN.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Name")]
        public System.String[] TrailNameList { get; set; }
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
            
            if (ParameterWasBound("IncludeShadowTrail"))
                context.IncludeShadowTrails = this.IncludeShadowTrail;
            if (this.TrailNameList != null)
            {
                context.TrailNameList = new List<System.String>(this.TrailNameList);
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
            var request = new Amazon.CloudTrail.Model.DescribeTrailsRequest();
            
            if (cmdletContext.IncludeShadowTrails != null)
            {
                request.IncludeShadowTrails = cmdletContext.IncludeShadowTrails.Value;
            }
            if (cmdletContext.TrailNameList != null)
            {
                request.TrailNameList = cmdletContext.TrailNameList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TrailList;
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
        
        private Amazon.CloudTrail.Model.DescribeTrailsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.DescribeTrailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "DescribeTrails");
            try
            {
                #if DESKTOP
                return client.DescribeTrails(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeTrailsAsync(request);
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
            public System.Boolean? IncludeShadowTrails { get; set; }
            public List<System.String> TrailNameList { get; set; }
        }
        
    }
}
