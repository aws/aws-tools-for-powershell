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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Describes the access that is assigned to the specific file transfer protocol-enabled
    /// server, as identified by its <c>ServerId</c> property and its <c>ExternalId</c>.
    /// 
    ///  
    /// <para>
    /// The response from this call returns the properties of the access that is associated
    /// with the <c>ServerId</c> value that was specified.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TFRAccess")]
    [OutputType("Amazon.Transfer.Model.DescribeAccessResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP DescribeAccess API operation.", Operation = new[] {"DescribeAccess"}, SelectReturnType = typeof(Amazon.Transfer.Model.DescribeAccessResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.DescribeAccessResponse",
        "This cmdlet returns an Amazon.Transfer.Model.DescribeAccessResponse object containing multiple properties."
    )]
    public partial class GetTFRAccessCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that is required to identify specific groups within your directory.
        /// The users of the group that you associate have access to your Amazon S3 or Amazon
        /// EFS resources over the enabled protocols using Transfer Family. If you know the group
        /// name, you can view the SID values by running the following command using Windows PowerShell.</para><para><c>Get-ADGroup -Filter {samAccountName -like "<i>YourGroupName</i>*"} -Properties
        /// * | Select SamAccountName,ObjectSid</c></para><para>In that command, replace <i>YourGroupName</i> with the name of your Active Directory
        /// group.</para><para>The regular expression used to validate this parameter is a string of characters consisting
        /// of uppercase and lowercase alphanumeric characters with no spaces. You can also include
        /// underscores or any of the following characters: =,.@:/-</para>
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
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a server that has this access assigned.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.DescribeAccessResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.DescribeAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.DescribeAccessResponse, GetTFRAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExternalId = this.ExternalId;
            #if MODULAR
            if (this.ExternalId == null && ParameterWasBound(nameof(this.ExternalId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.DescribeAccessRequest();
            
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
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
        
        private Amazon.Transfer.Model.DescribeAccessResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.DescribeAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "DescribeAccess");
            try
            {
                return client.DescribeAccessAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExternalId { get; set; }
            public System.String ServerId { get; set; }
            public System.Func<Amazon.Transfer.Model.DescribeAccessResponse, GetTFRAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
