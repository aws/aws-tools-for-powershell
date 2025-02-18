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
using System.Threading;
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Updates the specified parameters for a profile. A profile is the mechanism used to
    /// create the concept of a private network.
    /// </summary>
    [Cmdlet("Update", "B2BIProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.UpdateProfileResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange UpdateProfile API operation.", Operation = new[] {"UpdateProfile"}, SelectReturnType = typeof(Amazon.B2bi.Model.UpdateProfileResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.UpdateProfileResponse",
        "This cmdlet returns an Amazon.B2bi.Model.UpdateProfileResponse object containing multiple properties."
    )]
    public partial class UpdateB2BIProfileCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BusinessName
        /// <summary>
        /// <para>
        /// <para>Specifies the name for the business associated with this profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>Specifies the email address associated with this customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the profile, used to identify it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Phone
        /// <summary>
        /// <para>
        /// <para>Specifies the phone number associated with the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Phone { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique, system-generated identifier for the profile.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.UpdateProfileResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.UpdateProfileResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-B2BIProfile (UpdateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.UpdateProfileResponse, UpdateB2BIProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BusinessName = this.BusinessName;
            context.Email = this.Email;
            context.Name = this.Name;
            context.Phone = this.Phone;
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.B2bi.Model.UpdateProfileRequest();
            
            if (cmdletContext.BusinessName != null)
            {
                request.BusinessName = cmdletContext.BusinessName;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Phone != null)
            {
                request.Phone = cmdletContext.Phone;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
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
        
        private Amazon.B2bi.Model.UpdateProfileResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.UpdateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "UpdateProfile");
            try
            {
                return client.UpdateProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BusinessName { get; set; }
            public System.String Email { get; set; }
            public System.String Name { get; set; }
            public System.String Phone { get; set; }
            public System.String ProfileId { get; set; }
            public System.Func<Amazon.B2bi.Model.UpdateProfileResponse, UpdateB2BIProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
