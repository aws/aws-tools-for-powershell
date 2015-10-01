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
    /// Lists the tags for the trail in the current region.
    /// </summary>
    [Cmdlet("Get", "CTTag")]
    [OutputType("Amazon.CloudTrail.Model.ResourceTag")]
    [AWSCmdlet("Invokes the ListTags operation against AWS CloudTrail.", Operation = new[] {"ListTags"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.ResourceTag",
        "This cmdlet returns a collection of ResourceTag objects.",
        "The service call response (type ListTagsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCTTagCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specifies a list of trail ARNs whose tags will be listed. The list has a limit of
        /// 20 ARNs. The format of a trail ARN is <code>arn:aws:cloudtrail:us-east-1:123456789012:trail/MyTrail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ResourceIdList { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.NextToken = this.NextToken;
            if (this.ResourceIdList != null)
            {
                context.ResourceIdList = new List<String>(this.ResourceIdList);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListTagsRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceIdList != null)
            {
                request.ResourceIdList = cmdletContext.ResourceIdList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListTags(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceTagList;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String NextToken { get; set; }
            public List<String> ResourceIdList { get; set; }
        }
        
    }
}
