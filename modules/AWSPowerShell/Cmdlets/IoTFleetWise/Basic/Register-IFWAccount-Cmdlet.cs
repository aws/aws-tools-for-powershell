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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// <important><para>
    /// This API operation contains deprecated parameters. Register your account again without
    /// the Timestream resources parameter so that Amazon Web Services IoT FleetWise can remove
    /// the Timestream metadata stored. You should then pass the data destination into the
    /// <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/APIReference/API_CreateCampaign.html">CreateCampaign</a>
    /// API operation.
    /// </para><para>
    /// You must delete any existing campaigns that include an empty data destination before
    /// you register your account again. For more information, see the <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/APIReference/API_DeleteCampaign.html">DeleteCampaign</a>
    /// API operation.
    /// </para><para>
    /// If you want to delete the Timestream inline policy from the service-linked role, such
    /// as to mitigate an overly permissive policy, you must first delete any existing campaigns.
    /// Then delete the service-linked role and register your account again to enable CloudWatch
    /// metrics. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DeleteServiceLinkedRole.html">DeleteServiceLinkedRole</a>
    /// in the <i>Identity and Access Management API Reference</i>.
    /// </para></important><para>
    /// Registers your Amazon Web Services account, IAM, and Amazon Timestream resources so
    /// Amazon Web Services IoT FleetWise can transfer your vehicle data to the Amazon Web
    /// Services Cloud. For more information, including step-by-step procedures, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/setting-up.html">Setting
    /// up Amazon Web Services IoT FleetWise</a>. 
    /// </para><note><para>
    /// An Amazon Web Services account is <b>not</b> the same thing as a "user." An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/introduction_identity-management.html#intro-identity-users">Amazon
    /// Web Services user</a> is an identity that you create using Identity and Access Management
    /// (IAM) and takes the form of either an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_users.html">IAM
    /// user</a> or an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles.html">IAM
    /// role, both with credentials</a>. A single Amazon Web Services account can, and typically
    /// does, contain many users and roles.
    /// </para></note>
    /// </summary>
    [Cmdlet("Register", "IFWAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.RegisterAccountResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise RegisterAccount API operation.", Operation = new[] {"RegisterAccount"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.RegisterAccountResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.RegisterAccountResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.RegisterAccountResponse object containing multiple properties."
    )]
    public partial class RegisterIFWAccountCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IamResources_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM resource that allows Amazon Web Services
        /// IoT FleetWise to send data to Amazon Timestream. For example, <c>arn:aws:iam::123456789012:role/SERVICE-ROLE-ARN</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamResources_RoleArn { get; set; }
        #endregion
        
        #region Parameter TimestreamResources_TimestreamDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the registered Amazon Timestream database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TimestreamResources_TimestreamDatabaseName { get; set; }
        #endregion
        
        #region Parameter TimestreamResources_TimestreamTableName
        /// <summary>
        /// <para>
        /// <para>The name of the registered Amazon Timestream database table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimestreamResources_TimestreamTableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.RegisterAccountResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.RegisterAccountResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TimestreamResources_TimestreamDatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-IFWAccount (RegisterAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.RegisterAccountResponse, RegisterIFWAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IamResources_RoleArn = this.IamResources_RoleArn;
            context.TimestreamResources_TimestreamDatabaseName = this.TimestreamResources_TimestreamDatabaseName;
            context.TimestreamResources_TimestreamTableName = this.TimestreamResources_TimestreamTableName;
            
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
            var request = new Amazon.IoTFleetWise.Model.RegisterAccountRequest();
            
            
             // populate IamResources
            var requestIamResourcesIsNull = true;
            request.IamResources = new Amazon.IoTFleetWise.Model.IamResources();
            System.String requestIamResources_iamResources_RoleArn = null;
            if (cmdletContext.IamResources_RoleArn != null)
            {
                requestIamResources_iamResources_RoleArn = cmdletContext.IamResources_RoleArn;
            }
            if (requestIamResources_iamResources_RoleArn != null)
            {
                request.IamResources.RoleArn = requestIamResources_iamResources_RoleArn;
                requestIamResourcesIsNull = false;
            }
             // determine if request.IamResources should be set to null
            if (requestIamResourcesIsNull)
            {
                request.IamResources = null;
            }
            
             // populate TimestreamResources
            var requestTimestreamResourcesIsNull = true;
            request.TimestreamResources = new Amazon.IoTFleetWise.Model.TimestreamResources();
            System.String requestTimestreamResources_timestreamResources_TimestreamDatabaseName = null;
            if (cmdletContext.TimestreamResources_TimestreamDatabaseName != null)
            {
                requestTimestreamResources_timestreamResources_TimestreamDatabaseName = cmdletContext.TimestreamResources_TimestreamDatabaseName;
            }
            if (requestTimestreamResources_timestreamResources_TimestreamDatabaseName != null)
            {
                request.TimestreamResources.TimestreamDatabaseName = requestTimestreamResources_timestreamResources_TimestreamDatabaseName;
                requestTimestreamResourcesIsNull = false;
            }
            System.String requestTimestreamResources_timestreamResources_TimestreamTableName = null;
            if (cmdletContext.TimestreamResources_TimestreamTableName != null)
            {
                requestTimestreamResources_timestreamResources_TimestreamTableName = cmdletContext.TimestreamResources_TimestreamTableName;
            }
            if (requestTimestreamResources_timestreamResources_TimestreamTableName != null)
            {
                request.TimestreamResources.TimestreamTableName = requestTimestreamResources_timestreamResources_TimestreamTableName;
                requestTimestreamResourcesIsNull = false;
            }
             // determine if request.TimestreamResources should be set to null
            if (requestTimestreamResourcesIsNull)
            {
                request.TimestreamResources = null;
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
        
        private Amazon.IoTFleetWise.Model.RegisterAccountResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.RegisterAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "RegisterAccount");
            try
            {
                return client.RegisterAccountAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IamResources_RoleArn { get; set; }
            public System.String TimestreamResources_TimestreamDatabaseName { get; set; }
            public System.String TimestreamResources_TimestreamTableName { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.RegisterAccountResponse, RegisterIFWAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
