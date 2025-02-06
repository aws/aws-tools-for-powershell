/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a snapshot copy grant that permits Amazon Redshift to use an encrypted symmetric
    /// key from Key Management Service (KMS) to encrypt copied snapshots in a destination
    /// region.
    /// 
    ///  
    /// <para>
    ///  For more information about managing snapshot copy grants, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-db-encryption.html">Amazon
    /// Redshift Database Encryption</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSSnapshotCopyGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.SnapshotCopyGrant")]
    [AWSCmdlet("Calls the Amazon Redshift CreateSnapshotCopyGrant API operation.", Operation = new[] {"CreateSnapshotCopyGrant"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.SnapshotCopyGrant or Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse",
        "This cmdlet returns an Amazon.Redshift.Model.SnapshotCopyGrant object.",
        "The service call response (type Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRSSnapshotCopyGrantCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the encrypted symmetric key to which to grant Amazon Redshift
        /// permission. If no key is specified, the default key is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SnapshotCopyGrantName
        /// <summary>
        /// <para>
        /// <para>The name of the snapshot copy grant. This name must be unique in the region for the
        /// Amazon Web Services account.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an Amazon Web Services account.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnapshotCopyGrantName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapshotCopyGrant'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapshotCopyGrant";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotCopyGrantName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSnapshotCopyGrant (CreateSnapshotCopyGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse, NewRSSnapshotCopyGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyId = this.KmsKeyId;
            context.SnapshotCopyGrantName = this.SnapshotCopyGrantName;
            #if MODULAR
            if (this.SnapshotCopyGrantName == null && ParameterWasBound(nameof(this.SnapshotCopyGrantName)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotCopyGrantName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.CreateSnapshotCopyGrantAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateSnapshotCopyGrantResponse, NewRSSnapshotCopyGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapshotCopyGrant;
        }
        
    }
}
