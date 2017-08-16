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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates a snapshot copy grant that permits Amazon Redshift to use a customer master
    /// key (CMK) from AWS Key Management Service (AWS KMS) to encrypt copied snapshots in
    /// a destination region.
    /// 
    ///  
    /// <para>
    ///  For more information about managing snapshot copy grants, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-db-encryption.html">Amazon
    /// Redshift Database Encryption</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSSnapshotCopyGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.SnapshotCopyGrant")]
    [AWSCmdlet("Invokes the CreateSnapshotCopyGrant operation against Amazon Redshift.", Operation = new[] {"CreateSnapshotCopyGrant"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.SnapshotCopyGrant",
        "This cmdlet returns a SnapshotCopyGrant object.",
        "The service call response (type Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSSnapshotCopyGrantCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the customer master key (CMK) to which to grant Amazon Redshift
        /// permission. If no key is specified, the default key is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SnapshotCopyGrantName
        /// <summary>
        /// <para>
        /// <para>The name of the snapshot copy grant. This name must be unique in the region for the
        /// AWS account.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an AWS account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotCopyGrantName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotCopyGrantName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSnapshotCopyGrant (CreateSnapshotCopyGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.KmsKeyId = this.KmsKeyId;
            context.SnapshotCopyGrantName = this.SnapshotCopyGrantName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            var request = new Amazon.Redshift.Model.CreateSnapshotCopyGrantRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SnapshotCopyGrantName != null)
            {
                request.SnapshotCopyGrantName = cmdletContext.SnapshotCopyGrantName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SnapshotCopyGrant;
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
        
        private Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateSnapshotCopyGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateSnapshotCopyGrant");
            try
            {
                #if DESKTOP
                return client.CreateSnapshotCopyGrant(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateSnapshotCopyGrantAsync(request);
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
            public System.String KmsKeyId { get; set; }
            public System.String SnapshotCopyGrantName { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
        }
        
    }
}
