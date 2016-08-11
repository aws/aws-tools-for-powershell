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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Returns a link to an Amazon S3 presigned URL for the manifest file associated with
    /// the specified <code>JobId</code> value. You can access the manifest file for up to
    /// 60 minutes after this request has been made. To access the manifest file after 60
    /// minutes have passed, you'll have to make another call to the <code>GetJobManifest</code>
    /// action.
    /// 
    ///  
    /// <para>
    /// The manifest is an encrypted file that you can download after your job enters the
    /// <code>WithCustomer</code> status. The manifest is decrypted by using the <code>UnlockCode</code>
    /// code value, when you pass both values to the Snowball through the Snowball client
    /// when the client is started for the first time.
    /// </para><para>
    /// As a best practice, we recommend that you don't save a copy of an <code>UnlockCode</code>
    /// value in the same location as the manifest file for that job. Saving these separately
    /// helps prevent unauthorized parties from gaining access to the Snowball associated
    /// with that job.
    /// </para><para>
    /// Note that the credentials of a given job, including its manifest file and unlock code,
    /// expire 90 days after the job is created.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SNOWJobManifest")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetJobManifest operation against Amazon Import/Export Snowball.", Operation = new[] {"GetJobManifest"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Snowball.Model.GetJobManifestResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSNOWJobManifestCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The ID for a job that you want to get the manifest file for, for example <code>JID123e4567-e89b-12d3-a456-426655440000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.JobId = this.JobId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Snowball.Model.GetJobManifestRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ManifestURI;
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
        
        private static Amazon.Snowball.Model.GetJobManifestResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.GetJobManifestRequest request)
        {
            return client.GetJobManifest(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String JobId { get; set; }
        }
        
    }
}
