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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// List origin access identities.
    /// </summary>
    [Cmdlet("Get", "CFCloudFrontOriginAccessIdentities")]
    [OutputType("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentityList")]
    [AWSCmdlet("Invokes the ListCloudFrontOriginAccessIdentities operation against Amazon CloudFront.", Operation = new[] {"ListCloudFrontOriginAccessIdentities"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentityList",
        "This cmdlet returns a CloudFrontOriginAccessIdentityList object.",
        "The service call response (type Amazon.CloudFront.Model.ListCloudFrontOriginAccessIdentitiesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFCloudFrontOriginAccessIdentitiesCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// Use this when paginating results to indicate where
        /// to begin in your list of origin access identities. The results include identities
        /// in the list that occur after the marker. To get the next page of results, set the
        /// Marker to the value of the NextMarker from the current page's response (which is also
        /// the ID of the last identity on that page).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// The maximum number of origin access identities
        /// you want in the response body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
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
            
            context.Marker = this.Marker;
            context.MaxItems = this.MaxItem;
            
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
            var request = new Amazon.CloudFront.Model.ListCloudFrontOriginAccessIdentitiesRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CloudFrontOriginAccessIdentityList;
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
        
        private static Amazon.CloudFront.Model.ListCloudFrontOriginAccessIdentitiesResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListCloudFrontOriginAccessIdentitiesRequest request)
        {
            #if DESKTOP
            return client.ListCloudFrontOriginAccessIdentities(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListCloudFrontOriginAccessIdentitiesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Marker { get; set; }
            public System.String MaxItems { get; set; }
        }
        
    }
}
