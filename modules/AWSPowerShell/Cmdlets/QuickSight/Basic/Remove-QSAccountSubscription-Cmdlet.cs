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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// <important><para>
    /// Deleting your QuickSight account subscription has permanent, irreversible consequences
    /// across all Amazon Web Services regions:
    /// </para><ul><li><para>
    /// Global deletion – Running this operation from any single region will delete your QuickSight
    /// account and all data in every Amazon Web Services region where you have QuickSight
    /// resources.
    /// </para></li><li><para>
    /// Complete data loss – All dashboards, analyses, datasets, data sources, and custom
    /// visuals will be permanently deleted across all regions.
    /// </para></li><li><para>
    /// Embedded content failure – All embedded dashboards and visuals in your applications
    /// will immediately stop working and display errors to end users.
    /// </para></li><li><para>
    /// Shared resources removed – All shared dashboards, folders, and resources will become
    /// inaccessible to other users and external recipients.
    /// </para></li><li><para>
    /// User access terminated – All QuickSight users in your account will lose access immediately,
    /// including authors, readers, and administrators.
    /// </para></li><li><para><b>No recovery possible</b> – Once deleted, your QuickSight account and all associated
    /// data cannot be restored.
    /// </para></li></ul><para>
    /// Consider exporting critical dashboards and data before proceeding with account deletion.
    /// </para></important><para>
    /// Use the <c>DeleteAccountSubscription</c> operation to delete an QuickSight account.
    /// This operation will result in an error message if you have configured your account
    /// termination protection settings to <c>True</c>. To change this setting and delete
    /// your account, call the <c>UpdateAccountSettings</c> API and set the value of the <c>TerminationProtectionEnabled</c>
    /// parameter to <c>False</c>, then make another call to the <c>DeleteAccountSubscription</c>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "QSAccountSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight DeleteAccountSubscription API operation.", Operation = new[] {"DeleteAccountSubscription"}, SelectReturnType = typeof(Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse object containing multiple properties."
    )]
    public partial class RemoveQSAccountSubscriptionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the account that you want to delete.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-QSAccountSubscription (DeleteAccountSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse, RemoveQSAccountSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.DeleteAccountSubscriptionRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
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
        
        private Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.DeleteAccountSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "DeleteAccountSubscription");
            try
            {
                #if DESKTOP
                return client.DeleteAccountSubscription(request);
                #elif CORECLR
                return client.DeleteAccountSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.Func<Amazon.QuickSight.Model.DeleteAccountSubscriptionResponse, RemoveQSAccountSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
