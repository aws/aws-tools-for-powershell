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
    /// Replaces an IAM instance profile for the specified running instance. You can use this
    /// action to change the IAM instance profile that's associated with an instance without
    /// having to disassociate the existing IAM instance profile first.
    /// 
    ///  
    /// <para>
    /// Use <a>DescribeIamInstanceProfileAssociations</a> to get the association ID.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "EC2IamInstanceProfileAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IamInstanceProfileAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReplaceIamInstanceProfileAssociation API operation.", Operation = new[] {"ReplaceIamInstanceProfileAssociation"}, SelectReturnType = typeof(Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IamInstanceProfileAssociation or Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse",
        "This cmdlet returns an Amazon.EC2.Model.IamInstanceProfileAssociation object.",
        "The service call response (type Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetEC2IamInstanceProfileAssociationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the existing IAM instance profile association.</para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>The name of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IamInstanceProfileAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IamInstanceProfileAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EC2IamInstanceProfileAssociation (ReplaceIamInstanceProfileAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse, SetEC2IamInstanceProfileAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            
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
            var request = new Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            
             // populate IamInstanceProfile
            var requestIamInstanceProfileIsNull = true;
            request.IamInstanceProfile = new Amazon.EC2.Model.IamInstanceProfileSpecification();
            System.String requestIamInstanceProfile_iamInstanceProfile_Arn = null;
            if (cmdletContext.IamInstanceProfile_Arn != null)
            {
                requestIamInstanceProfile_iamInstanceProfile_Arn = cmdletContext.IamInstanceProfile_Arn;
            }
            if (requestIamInstanceProfile_iamInstanceProfile_Arn != null)
            {
                request.IamInstanceProfile.Arn = requestIamInstanceProfile_iamInstanceProfile_Arn;
                requestIamInstanceProfileIsNull = false;
            }
            System.String requestIamInstanceProfile_iamInstanceProfile_Name = null;
            if (cmdletContext.IamInstanceProfile_Name != null)
            {
                requestIamInstanceProfile_iamInstanceProfile_Name = cmdletContext.IamInstanceProfile_Name;
            }
            if (requestIamInstanceProfile_iamInstanceProfile_Name != null)
            {
                request.IamInstanceProfile.Name = requestIamInstanceProfile_iamInstanceProfile_Name;
                requestIamInstanceProfileIsNull = false;
            }
             // determine if request.IamInstanceProfile should be set to null
            if (requestIamInstanceProfileIsNull)
            {
                request.IamInstanceProfile = null;
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
        
        private Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReplaceIamInstanceProfileAssociation");
            try
            {
                #if DESKTOP
                return client.ReplaceIamInstanceProfileAssociation(request);
                #elif CORECLR
                return client.ReplaceIamInstanceProfileAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String IamInstanceProfile_Arn { get; set; }
            public System.String IamInstanceProfile_Name { get; set; }
            public System.Func<Amazon.EC2.Model.ReplaceIamInstanceProfileAssociationResponse, SetEC2IamInstanceProfileAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IamInstanceProfileAssociation;
        }
        
    }
}
