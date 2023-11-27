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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Configures whether participant accounts in your organization can create Amazon FSx
    /// for NetApp ONTAP Multi-AZ file systems in subnets that are shared by a virtual private
    /// cloud (VPC) owner. For more information, see the <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/maz-shared-vpc.html">Amazon
    /// FSx for NetApp ONTAP User Guide</a>.
    /// 
    ///  <note><para>
    /// We strongly recommend that participant-created Multi-AZ file systems in the shared
    /// VPC are deleted before you disable this feature. Once the feature is disabled, these
    /// file systems will enter a <code>MISCONFIGURED</code> state and behave like Single-AZ
    /// file systems. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/maz-shared-vpc.html#disabling-maz-vpc-sharing">Important
    /// considerations before disabling shared VPC support for Multi-AZ file systems</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "FSXSharedVpcConfiguration")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon FSx UpdateSharedVpcConfiguration API operation.", Operation = new[] {"UpdateSharedVpcConfiguration"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFSXSharedVpcConfigurationCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter EnableFsxRouteTableUpdatesFromParticipantAccount
        /// <summary>
        /// <para>
        /// <para>Specifies whether participant accounts can create FSx for ONTAP Multi-AZ file systems
        /// in shared subnets. Set to <code>true</code> to enable or <code>false</code> to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableFsxRouteTableUpdatesFromParticipantAccounts")]
        public System.String EnableFsxRouteTableUpdatesFromParticipantAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnableFsxRouteTableUpdatesFromParticipantAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnableFsxRouteTableUpdatesFromParticipantAccounts";
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
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse, UpdateFSXSharedVpcConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.EnableFsxRouteTableUpdatesFromParticipantAccount = this.EnableFsxRouteTableUpdatesFromParticipantAccount;
            
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
            var request = new Amazon.FSx.Model.UpdateSharedVpcConfigurationRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.EnableFsxRouteTableUpdatesFromParticipantAccount != null)
            {
                request.EnableFsxRouteTableUpdatesFromParticipantAccounts = cmdletContext.EnableFsxRouteTableUpdatesFromParticipantAccount;
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
        
        private Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateSharedVpcConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateSharedVpcConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateSharedVpcConfiguration(request);
                #elif CORECLR
                return client.UpdateSharedVpcConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String EnableFsxRouteTableUpdatesFromParticipantAccount { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateSharedVpcConfigurationResponse, UpdateFSXSharedVpcConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnableFsxRouteTableUpdatesFromParticipantAccounts;
        }
        
    }
}
