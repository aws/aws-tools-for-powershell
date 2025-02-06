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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Gets basic information about the security profile.
    /// 
    ///  
    /// <para>
    /// For information about security profiles, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/connect-security-profiles.html">Security
    /// Profiles</a> in the <i>Amazon Connect Administrator Guide</i>. For a mapping of the
    /// API name and user interface name of the security profile permissions, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-profile-list.html">List
    /// of security profile permissions</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CONNSecurityProfile")]
    [OutputType("Amazon.Connect.Model.SecurityProfile")]
    [AWSCmdlet("Calls the Amazon Connect Service DescribeSecurityProfile API operation.", Operation = new[] {"DescribeSecurityProfile"}, SelectReturnType = typeof(Amazon.Connect.Model.DescribeSecurityProfileResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SecurityProfile or Amazon.Connect.Model.DescribeSecurityProfileResponse",
        "This cmdlet returns an Amazon.Connect.Model.SecurityProfile object.",
        "The service call response (type Amazon.Connect.Model.DescribeSecurityProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNSecurityProfileCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter SecurityProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier for the security profle.</para>
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
        public System.String SecurityProfileId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DescribeSecurityProfileResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.DescribeSecurityProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityProfile";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DescribeSecurityProfileResponse, GetCONNSecurityProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityProfileId = this.SecurityProfileId;
            #if MODULAR
            if (this.SecurityProfileId == null && ParameterWasBound(nameof(this.SecurityProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DescribeSecurityProfileRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.SecurityProfileId != null)
            {
                request.SecurityProfileId = cmdletContext.SecurityProfileId;
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
        
        private Amazon.Connect.Model.DescribeSecurityProfileResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DescribeSecurityProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DescribeSecurityProfile");
            try
            {
                #if DESKTOP
                return client.DescribeSecurityProfile(request);
                #elif CORECLR
                return client.DescribeSecurityProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String SecurityProfileId { get; set; }
            public System.Func<Amazon.Connect.Model.DescribeSecurityProfileResponse, GetCONNSecurityProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityProfile;
        }
        
    }
}
