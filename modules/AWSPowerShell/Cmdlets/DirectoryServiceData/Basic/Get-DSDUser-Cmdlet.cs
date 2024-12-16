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
using Amazon.DirectoryServiceData;
using Amazon.DirectoryServiceData.Model;

namespace Amazon.PowerShell.Cmdlets.DSD
{
    /// <summary>
    /// Returns information about a specific user.
    /// </summary>
    [Cmdlet("Get", "DSDUser")]
    [OutputType("Amazon.DirectoryServiceData.Model.DescribeUserResponse")]
    [AWSCmdlet("Calls the AWS Directory Service Data DescribeUser API operation.", Operation = new[] {"DescribeUser"}, SelectReturnType = typeof(Amazon.DirectoryServiceData.Model.DescribeUserResponse))]
    [AWSCmdletOutput("Amazon.DirectoryServiceData.Model.DescribeUserResponse",
        "This cmdlet returns an Amazon.DirectoryServiceData.Model.DescribeUserResponse object containing multiple properties."
    )]
    public partial class GetDSDUserCmdlet : AmazonDirectoryServiceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para> The identifier (ID) of the directory that's associated with the user. </para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter OtherAttribute
        /// <summary>
        /// <para>
        /// <para> One or more attribute names to be returned for the user. A key is an attribute name,
        /// and the value is a list of maps. For a list of supported attributes, see <a href="https://docs.aws.amazon.com/directoryservice/latest/admin-guide/ad_data_attributes.html">Directory
        /// Service Data Attributes</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OtherAttributes")]
        public System.String[] OtherAttribute { get; set; }
        #endregion
        
        #region Parameter Realm
        /// <summary>
        /// <para>
        /// <para> The domain name that's associated with the user. </para><note><para> This parameter is optional, so you can return users outside your Managed Microsoft
        /// AD domain. When no value is defined, only your Managed Microsoft AD users are returned.
        /// </para><para> This value is case insensitive. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Realm { get; set; }
        #endregion
        
        #region Parameter SAMAccountName
        /// <summary>
        /// <para>
        /// <para> The name of the user. </para>
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
        public System.String SAMAccountName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryServiceData.Model.DescribeUserResponse).
        /// Specifying the name of a property of type Amazon.DirectoryServiceData.Model.DescribeUserResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.DirectoryServiceData.Model.DescribeUserResponse, GetDSDUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OtherAttribute != null)
            {
                context.OtherAttribute = new List<System.String>(this.OtherAttribute);
            }
            context.Realm = this.Realm;
            context.SAMAccountName = this.SAMAccountName;
            #if MODULAR
            if (this.SAMAccountName == null && ParameterWasBound(nameof(this.SAMAccountName)))
            {
                WriteWarning("You are passing $null as a value for parameter SAMAccountName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryServiceData.Model.DescribeUserRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.OtherAttribute != null)
            {
                request.OtherAttributes = cmdletContext.OtherAttribute;
            }
            if (cmdletContext.Realm != null)
            {
                request.Realm = cmdletContext.Realm;
            }
            if (cmdletContext.SAMAccountName != null)
            {
                request.SAMAccountName = cmdletContext.SAMAccountName;
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
        
        private Amazon.DirectoryServiceData.Model.DescribeUserResponse CallAWSServiceOperation(IAmazonDirectoryServiceData client, Amazon.DirectoryServiceData.Model.DescribeUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service Data", "DescribeUser");
            try
            {
                #if DESKTOP
                return client.DescribeUser(request);
                #elif CORECLR
                return client.DescribeUserAsync(request).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public List<System.String> OtherAttribute { get; set; }
            public System.String Realm { get; set; }
            public System.String SAMAccountName { get; set; }
            public System.Func<Amazon.DirectoryServiceData.Model.DescribeUserResponse, GetDSDUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
