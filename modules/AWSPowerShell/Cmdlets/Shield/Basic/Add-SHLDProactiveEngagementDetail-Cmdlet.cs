/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Initializes proactive engagement and sets the list of contacts for the Shield Response
    /// Team (SRT) to use. You must provide at least one phone number in the emergency contact
    /// list. 
    /// 
    ///  
    /// <para>
    /// After you have initialized proactive engagement using this call, to disable or enable
    /// proactive engagement, use the calls <c>DisableProactiveEngagement</c> and <c>EnableProactiveEngagement</c>.
    /// 
    /// </para><note><para>
    /// This call defines the list of email addresses and phone numbers that the SRT can use
    /// to contact you for escalations to the SRT and to initiate proactive customer support.
    /// </para><para>
    /// The contacts that you provide in the request replace any contacts that were already
    /// defined. If you already have contacts defined and want to use them, retrieve the list
    /// using <c>DescribeEmergencyContactSettings</c> and then provide it to this call. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "SHLDProactiveEngagementDetail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield AssociateProactiveEngagementDetails API operation.", Operation = new[] {"AssociateProactiveEngagementDetails"}, SelectReturnType = typeof(Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddSHLDProactiveEngagementDetailCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmergencyContactList
        /// <summary>
        /// <para>
        /// <para>A list of email addresses and phone numbers that the Shield Response Team (SRT) can
        /// use to contact you for escalations to the SRT and to initiate proactive customer support.
        /// </para><para>To enable proactive engagement, the contact list must include at least one phone number.</para><note><para>The contacts that you provide here replace any contacts that were already defined.
        /// If you already have contacts defined and want to use them, retrieve the list using
        /// <c>DescribeEmergencyContactSettings</c> and then provide it here. </para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Shield.Model.EmergencyContact[] EmergencyContactList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmergencyContactList), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SHLDProactiveEngagementDetail (AssociateProactiveEngagementDetails)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse, AddSHLDProactiveEngagementDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EmergencyContactList != null)
            {
                context.EmergencyContactList = new List<Amazon.Shield.Model.EmergencyContact>(this.EmergencyContactList);
            }
            #if MODULAR
            if (this.EmergencyContactList == null && ParameterWasBound(nameof(this.EmergencyContactList)))
            {
                WriteWarning("You are passing $null as a value for parameter EmergencyContactList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Shield.Model.AssociateProactiveEngagementDetailsRequest();
            
            if (cmdletContext.EmergencyContactList != null)
            {
                request.EmergencyContactList = cmdletContext.EmergencyContactList;
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
        
        private Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.AssociateProactiveEngagementDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "AssociateProactiveEngagementDetails");
            try
            {
                #if DESKTOP
                return client.AssociateProactiveEngagementDetails(request);
                #elif CORECLR
                return client.AssociateProactiveEngagementDetailsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Shield.Model.EmergencyContact> EmergencyContactList { get; set; }
            public System.Func<Amazon.Shield.Model.AssociateProactiveEngagementDetailsResponse, AddSHLDProactiveEngagementDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
