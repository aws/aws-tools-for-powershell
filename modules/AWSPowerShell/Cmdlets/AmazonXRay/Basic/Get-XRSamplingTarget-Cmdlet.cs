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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Requests a sampling quota for rules that the service is using to sample requests.
    /// </summary>
    [Cmdlet("Get", "XRSamplingTarget")]
    [OutputType("Amazon.XRay.Model.GetSamplingTargetsResponse")]
    [AWSCmdlet("Calls the AWS X-Ray GetSamplingTargets API operation.", Operation = new[] {"GetSamplingTargets"})]
    [AWSCmdletOutput("Amazon.XRay.Model.GetSamplingTargetsResponse",
        "This cmdlet returns a Amazon.XRay.Model.GetSamplingTargetsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetXRSamplingTargetCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        #region Parameter SamplingStatisticsDocument
        /// <summary>
        /// <para>
        /// <para>Information about rules that the service is using to sample requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("SamplingStatisticsDocuments")]
        public Amazon.XRay.Model.SamplingStatisticsDocument[] SamplingStatisticsDocument { get; set; }
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
            
            if (this.SamplingStatisticsDocument != null)
            {
                context.SamplingStatisticsDocuments = new List<Amazon.XRay.Model.SamplingStatisticsDocument>(this.SamplingStatisticsDocument);
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
            var request = new Amazon.XRay.Model.GetSamplingTargetsRequest();
            
            if (cmdletContext.SamplingStatisticsDocuments != null)
            {
                request.SamplingStatisticsDocuments = cmdletContext.SamplingStatisticsDocuments;
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
        
        private Amazon.XRay.Model.GetSamplingTargetsResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetSamplingTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetSamplingTargets");
            try
            {
                #if DESKTOP
                return client.GetSamplingTargets(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetSamplingTargetsAsync(request);
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
            public List<Amazon.XRay.Model.SamplingStatisticsDocument> SamplingStatisticsDocuments { get; set; }
        }
        
    }
}
