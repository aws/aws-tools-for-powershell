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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Returns a JSON-formatted list of information about the specified trail. Fields include
    /// information on delivery errors, Amazon SNS and Amazon S3 errors, and start and stop
    /// logging times for each trail. This operation returns trail status from a single region.
    /// To return trail status from all regions, you must call the operation on each region.
    /// </summary>
    [Cmdlet("Get", "CTTrailStatus")]
    [OutputType("Amazon.CloudTrail.Model.GetTrailStatusResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail GetTrailStatus API operation.", Operation = new[] {"GetTrailStatus"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.GetTrailStatusResponse",
        "This cmdlet returns a Amazon.CloudTrail.Model.GetTrailStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCTTrailStatusCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name or the CloudTrail ARN of the trail for which you are requesting
        /// status. To get the status of a shadow trail (a replication of the trail in another
        /// region), you must specify its ARN. The format of a trail ARN is:</para><para><code>arn:aws:cloudtrail:us-east-2:123456789012:trail/MyTrail</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
            
            context.Name = this.Name;
            
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
            var request = new Amazon.CloudTrail.Model.GetTrailStatusRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudTrail.Model.GetTrailStatusResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.GetTrailStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "GetTrailStatus");
            try
            {
                #if DESKTOP
                return client.GetTrailStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetTrailStatusAsync(request);
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
            public System.String Name { get; set; }
        }
        
    }
}
