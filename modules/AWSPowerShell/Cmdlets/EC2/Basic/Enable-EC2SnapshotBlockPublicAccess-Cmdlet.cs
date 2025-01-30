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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enables or modifies the <i>block public access for snapshots</i> setting at the account
    /// level for the specified Amazon Web Services Region. After you enable block public
    /// access for snapshots in a Region, users can no longer request public sharing for snapshots
    /// in that Region. Snapshots that are already publicly shared are either treated as private
    /// or they remain publicly shared, depending on the <b>State</b> that you specify.
    /// 
    ///  <important><para>
    /// Enabling block public access for snapshots in <i>block all sharing</i> mode does not
    /// change the permissions for snapshots that are already publicly shared. Instead, it
    /// prevents these snapshots from be publicly visible and publicly accessible. Therefore,
    /// the attributes for these snapshots still indicate that they are publicly shared, even
    /// though they are not publicly available.
    /// </para><para>
    /// If you later disable block public access or change the mode to <i>block new sharing</i>,
    /// these snapshots will become publicly available again.
    /// </para></important><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/block-public-access-snapshots.html">
    /// Block public access for snapshots</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2SnapshotBlockPublicAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.SnapshotBlockPublicAccessState")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableSnapshotBlockPublicAccess API operation.", Operation = new[] {"EnableSnapshotBlockPublicAccess"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse))]
    [AWSCmdletOutput("Amazon.EC2.SnapshotBlockPublicAccessState or Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse",
        "This cmdlet returns an Amazon.EC2.SnapshotBlockPublicAccessState object.",
        "The service call response (type Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2SnapshotBlockPublicAccessCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The mode in which to enable block public access for snapshots for the Region. Specify
        /// one of the following values:</para><ul><li><para><c>block-all-sharing</c> - Prevents all public sharing of snapshots in the Region.
        /// Users in the account will no longer be able to request new public sharing. Additionally,
        /// snapshots that are already publicly shared are treated as private and they are no
        /// longer publicly available.</para></li><li><para><c>block-new-sharing</c> - Prevents only new public sharing of snapshots in the Region.
        /// Users in the account will no longer be able to request new public sharing. However,
        /// snapshots that are already publicly shared, remain publicly available.</para></li></ul><para><c>unblocked</c> is not a valid value for <b>EnableSnapshotBlockPublicAccess</b>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.SnapshotBlockPublicAccessState")]
        public Amazon.EC2.SnapshotBlockPublicAccessState State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'State'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "State";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the State parameter.
        /// The -PassThru parameter is deprecated, use -Select '^State' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^State' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.State), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2SnapshotBlockPublicAccess (EnableSnapshotBlockPublicAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse, EnableEC2SnapshotBlockPublicAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.State;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.State = this.State;
            #if MODULAR
            if (this.State == null && ParameterWasBound(nameof(this.State)))
            {
                WriteWarning("You are passing $null as a value for parameter State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.EnableSnapshotBlockPublicAccessRequest();
            
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableSnapshotBlockPublicAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableSnapshotBlockPublicAccess");
            try
            {
                #if DESKTOP
                return client.EnableSnapshotBlockPublicAccess(request);
                #elif CORECLR
                return client.EnableSnapshotBlockPublicAccessAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.SnapshotBlockPublicAccessState State { get; set; }
            public System.Func<Amazon.EC2.Model.EnableSnapshotBlockPublicAccessResponse, EnableEC2SnapshotBlockPublicAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.State;
        }
        
    }
}
