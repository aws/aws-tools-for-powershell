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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates, changes, or deletes CIDR blocks within a collection. Contains authoritative
    /// IP information mapping blocks to one or multiple locations.
    /// 
    ///  
    /// <para>
    /// A change request can update multiple locations in a collection at a time, which is
    /// helpful if you want to move one or more CIDR blocks from one location to another in
    /// one transaction, without downtime. 
    /// </para><para><b>Limits</b></para><para>
    /// The max number of CIDR blocks included in the request is 1000. As a result, big updates
    /// require multiple API calls.
    /// </para><para><b> PUT and DELETE_IF_EXISTS</b></para><para>
    /// Use <code>ChangeCidrCollection</code> to perform the following actions:
    /// </para><ul><li><para><code>PUT</code>: Create a CIDR block within the specified collection.
    /// </para></li><li><para><code> DELETE_IF_EXISTS</code>: Delete an existing CIDR block from the collection.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Edit", "R53CidrCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 ChangeCidrCollection API operation.", Operation = new[] {"ChangeCidrCollection"}, SelectReturnType = typeof(Amazon.Route53.Model.ChangeCidrCollectionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53.Model.ChangeCidrCollectionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53.Model.ChangeCidrCollectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditR53CidrCollectionCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Change
        /// <summary>
        /// <para>
        /// <para> Information about changes to a CIDR collection.</para>
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
        [Alias("Changes")]
        public Amazon.Route53.Model.CidrCollectionChange[] Change { get; set; }
        #endregion
        
        #region Parameter CollectionVersion
        /// <summary>
        /// <para>
        /// <para>A sequential counter that Amazon Route 53 sets to 1 when you create a collection and
        /// increments it by 1 each time you update the collection.</para><para>We recommend that you use <code>ListCidrCollection</code> to get the current value
        /// of <code>CollectionVersion</code> for the collection that you want to update, and
        /// then include that value with the change request. This prevents Route 53 from overwriting
        /// an intervening update: </para><ul><li><para>If the value in the request matches the value of <code>CollectionVersion</code> in
        /// the collection, Route 53 updates the collection.</para></li><li><para>If the value of <code>CollectionVersion</code> in the collection is greater than the
        /// value in the request, the collection was changed after you got the version number.
        /// Route 53 does not update the collection, and it returns a <code>CidrCollectionVersionMismatch</code>
        /// error. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CollectionVersion { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The UUID of the CIDR collection to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ChangeCidrCollectionResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ChangeCidrCollectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-R53CidrCollection (ChangeCidrCollection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ChangeCidrCollectionResponse, EditR53CidrCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CollectionVersion = this.CollectionVersion;
            if (this.Change != null)
            {
                context.Change = new List<Amazon.Route53.Model.CidrCollectionChange>(this.Change);
            }
            #if MODULAR
            if (this.Change == null && ParameterWasBound(nameof(this.Change)))
            {
                WriteWarning("You are passing $null as a value for parameter Change which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.ChangeCidrCollectionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.CollectionVersion != null)
            {
                request.CollectionVersion = cmdletContext.CollectionVersion.Value;
            }
            if (cmdletContext.Change != null)
            {
                request.Changes = cmdletContext.Change;
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
        
        private Amazon.Route53.Model.ChangeCidrCollectionResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ChangeCidrCollectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ChangeCidrCollection");
            try
            {
                #if DESKTOP
                return client.ChangeCidrCollection(request);
                #elif CORECLR
                return client.ChangeCidrCollectionAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Int64? CollectionVersion { get; set; }
            public List<Amazon.Route53.Model.CidrCollectionChange> Change { get; set; }
            public System.Func<Amazon.Route53.Model.ChangeCidrCollectionResponse, EditR53CidrCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
