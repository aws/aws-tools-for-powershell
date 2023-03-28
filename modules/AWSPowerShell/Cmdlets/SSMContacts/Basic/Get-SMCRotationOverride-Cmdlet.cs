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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Retrieves information about an override to an on-call rotation.
    /// </summary>
    [Cmdlet("Get", "SMCRotationOverride")]
    [OutputType("Amazon.SSMContacts.Model.GetRotationOverrideResponse")]
    [AWSCmdlet("Calls the AWS System Manager Contacts GetRotationOverride API operation.", Operation = new[] {"GetRotationOverride"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.GetRotationOverrideResponse))]
    [AWSCmdletOutput("Amazon.SSMContacts.Model.GetRotationOverrideResponse",
        "This cmdlet returns an Amazon.SSMContacts.Model.GetRotationOverrideResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMCRotationOverrideCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        #region Parameter RotationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the overridden rotation to retrieve information
        /// about.</para>
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
        public System.String RotationId { get; set; }
        #endregion
        
        #region Parameter RotationOverrideId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the on-call rotation override to retrieve information
        /// about.</para>
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
        public System.String RotationOverrideId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.GetRotationOverrideResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.GetRotationOverrideResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.GetRotationOverrideResponse, GetSMCRotationOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RotationId = this.RotationId;
            #if MODULAR
            if (this.RotationId == null && ParameterWasBound(nameof(this.RotationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RotationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RotationOverrideId = this.RotationOverrideId;
            #if MODULAR
            if (this.RotationOverrideId == null && ParameterWasBound(nameof(this.RotationOverrideId)))
            {
                WriteWarning("You are passing $null as a value for parameter RotationOverrideId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.GetRotationOverrideRequest();
            
            if (cmdletContext.RotationId != null)
            {
                request.RotationId = cmdletContext.RotationId;
            }
            if (cmdletContext.RotationOverrideId != null)
            {
                request.RotationOverrideId = cmdletContext.RotationOverrideId;
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
        
        private Amazon.SSMContacts.Model.GetRotationOverrideResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.GetRotationOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS System Manager Contacts", "GetRotationOverride");
            try
            {
                #if DESKTOP
                return client.GetRotationOverride(request);
                #elif CORECLR
                return client.GetRotationOverrideAsync(request).GetAwaiter().GetResult();
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
            public System.String RotationId { get; set; }
            public System.String RotationOverrideId { get; set; }
            public System.Func<Amazon.SSMContacts.Model.GetRotationOverrideResponse, GetSMCRotationOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
