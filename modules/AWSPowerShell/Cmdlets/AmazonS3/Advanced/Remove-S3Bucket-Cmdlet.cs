/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3.Model;
using Amazon.S3.Util;

using Amazon.PowerShell.Properties;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Deletes an S3 bucket, optionally deleting remaining bucket content first (non-empty buckets cannot be deleted).
    /// </summary>
    [Cmdlet("Remove", "S3Bucket", SupportsShouldProcess=true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.S3.Model.DeleteBucketResponse")]
    [AWSCmdlet("Invokes the DeleteBucket method against Amazon Simple Storage Service. "
                + "Use the -DeleteBucketContent switch to delete any objects and/or object versions the bucket contains prior to bucket deletion (non-empty buckets cannot be deleted).",
                    Operation = new [] {"DeleteBucket"}
    )]
    [AWSCmdletOutput("Amazon.S3.Model.DeleteBucketResponse",
                     "Returns the service response (type Amazon.S3.Model.DeleteBucketResponse).",
                     "The service response is also added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        /// <summary>
        /// The name of the bucket to be deleted.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }

        /// <summary>
        /// <para>
        /// If set, all remaining objects and/or object versions in the bucket are deleted proir to the bucket itself 
        /// being deleted.
        /// </para>
        /// <para>Default: Off.</para>
        /// <para>
        /// Buckets that contain objects cannot be deleted.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("DeleteObjects")]
        public SwitchParameter DeleteBucketContent { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "Remove-S3Bucket (DeleteBucket)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName,
                DeleteObjects = this.DeleteBucketContent
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            CmdletOutput output;
            if (cmdletContext.DeleteObjects)
            {
                AmazonS3Util.DeleteS3BucketWithObjects(Client,
                                                       cmdletContext.BucketName, 
                                                       new S3DeleteBucketWithObjectsOptions 
                                                       { 
                                                           ContinueOnError = false 
                                                       });
                output = null;
            }
            else
            {
                var request = new DeleteBucketRequest {BucketName = cmdletContext.BucketName};

                using (var client = Client ?? CreateClient(context.Credentials, context.Region))
                {
                    try
                    {
                        var response = client.DeleteBucket(request);
                        output = new CmdletOutput
                        {
                            PipelineOutput = response,
                            ServiceResponse = response,
                        };
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                }
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
            public String BucketName { get; set; }
            public bool DeleteObjects { get; set; }
        }
        
    }
}
