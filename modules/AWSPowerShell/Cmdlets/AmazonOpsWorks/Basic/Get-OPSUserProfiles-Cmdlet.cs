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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describe specified users.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have an attached
    /// policy that explicitly grants permissions. For more information on user permissions,
    /// see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OPSUserProfiles")]
    [OutputType("Amazon.OpsWorks.Model.UserProfile")]
    [AWSCmdlet("Invokes the DescribeUserProfiles operation against AWS OpsWorks.", Operation = new[] {"DescribeUserProfiles"})]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.UserProfile",
        "This cmdlet returns a collection of UserProfile objects.",
        "The service call response (type Amazon.OpsWorks.Model.DescribeUserProfilesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetOPSUserProfilesCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter IamUserArn
        /// <summary>
        /// <para>
        /// <para>An array of IAM user ARNs that identify the users to be described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("IamUserArns")]
        public System.String[] IamUserArn { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.IamUserArn != null)
            {
                context.IamUserArns = new List<System.String>(this.IamUserArn);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.OpsWorks.Model.DescribeUserProfilesRequest();
            
            if (cmdletContext.IamUserArns != null)
            {
                request.IamUserArns = cmdletContext.IamUserArns;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.UserProfiles;
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
        
        private static Amazon.OpsWorks.Model.DescribeUserProfilesResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.DescribeUserProfilesRequest request)
        {
            return client.DescribeUserProfiles(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> IamUserArns { get; set; }
        }
        
    }
}
